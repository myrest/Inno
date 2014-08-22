using CWB.Web.Configuration;
using InnoThink.Core;
using InnoThink.Core.Cache.SignalR;
using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.Model;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Website.Communication;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System;
using System.Linq;
using System.Web.Mvc;
using InnoThink.BLL.User;
using InnoThink.Domain.Facebook;
using InnoThink.Domain;
using InnoThink.BLL.BackofficeUser;

namespace InnoThink.Website.Controllers.Service
{
    public class LoginServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(LoginServiceController));

        

        public LoginServiceController()
            : base(Permission.Public)
        {
        }

        private void MakeTrading(string LoginId)
        {
            Trading trading = new Trading() { };
            if (sessionData == null && sessionData.trading != null)
            {
                trading = sessionData.trading;
            }
            User_Manager um = new User_Manager();
            var user = um.GetByParameter(new User_Filter()
            {
                LoginId = LoginId
            }).FirstOrDefault();

            trading.LoginId = LoginId;
            trading.Picture = user.Picture;
            trading.UserName = user.UserName;
            trading.UserSN = user.UserSN;
            sessionData.trading = trading;
        }

        [HttpPost]
        public JsonResult FBLogin(string token)
        {
            ResultBase result = new ResultBase();
            sessionData.trading = new Trading();
            FacebookPersonAuth FBObject = FBUtility.GetUserID(token);
            User_Manager um = new User_Manager();
            if (um.FBLoginCheck(FBObject))
            {
                MakeTrading(FBObject.Email);
                sessionData.trading.isLogined = true;
                result.JsonReturnCode = 1;
            }
            else
            {
                result.setException("Facebook login failed, please try again.", "FBLogin");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult SignalrLogin(string ConnectionId)
        {
            ResultBase result = new ResultBase();
            if (sessionData.trading != null && sessionData.trading.UserSN > 0)
            {
                ConnectionManageBase.Update(ConnectionId, sessionData.trading.UserSN);
            }
            //Sync all the team member at the same TopicSN
            User_Manager um = new User_Manager();
            var user = um.GetBySN(sessionData.trading.UserSN);
            user.Picture = StringUtility.ConvertPicturePath(user.Picture);
            var cacheobj = ConnectionManageBase.GetByUserSN(sessionData.trading.UserSN);
            CommServer.Instance.syncOnlineUser(cacheobj.TopicSN, user);
            result.setMessage("Done");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult Login(string username, string password, string verify)
        {
            ResultBase result = new ResultBase();
            sessionData.trading = new Trading();
            try
            {
                if (AppConfigManager.SystemSetting.CaptchaCode && verify != (string)Session[SessionKeys.VerifyCode.ToString()])
                {
                    result.setException(new Exception("驗證碼錯誤。"), "LoginService");
                }
                else
                {
                    User_Manager um = new User_Manager();
                    if (um.isPasswordCorrect(username, password))
                    {
                        result.setMessage("登入成功。");
                        MakeTrading(username);
                        sessionData.trading.isLogined = true;
                        Log.Debug(string.Format("User [{0}] Logined.", username));
                    }
                    else
                    {
                        result.setException(new Exception("帳號或密碼錯誤。"), "LoginService");
                        Log.Debug(string.Format("User [{0}] Login failed.", username));
                    }
                }
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult LoginAdmin(string username, string password, string verify)
        {
            ResultBase result = new ResultBase();
            sessionData.trading = new Trading();
            try
            {
                if (AppConfigManager.SystemSetting.CaptchaCode && verify != (string)Session[SessionKeys.VerifyCode.ToString()])
                {
                    result.setException(new Exception("驗證碼錯誤。"), "LoginService");
                }
                else
                {
                    BackofficeUser_Manager bm = new BackofficeUser_Manager();
                    if (bm.isPasswordCorrect(username, password))
                    {
                        result.setMessage("登入成功。");
                        MakeAdminTrading(username);
                        sessionData.trading.isLogined = true;
                        Log.Debug(string.Format("User [{0}] Logined.", username));
                    }
                    else
                    {
                        result.setException(new Exception("帳號或密碼錯誤。"), "LoginService");
                        Log.Debug(string.Format("User [{0}] Login failed.", username));
                    }
                }
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.DenyGet);
            }
        }

        private void MakeAdminTrading(string username)
        {
            Trading trading = new Trading() { };
            if (sessionData == null && sessionData.trading != null)
            {
                trading = sessionData.trading;
            }
            BackofficeUser_Manager bm = new BackofficeUser_Manager();
            var bouser = bm.GetByParameter(new BackofficeUser_Filter()
            {
                LoginId = username
            }).FirstOrDefault();

            trading.LoginId = username;
            trading.UserSN = bouser.BackofficeUserSN;
            trading.Level = bouser.Level;
            sessionData.trading = trading;
        }

        [HttpPost]
        public JsonResult RegistryAdmin(string username, string password)
        {
            ResultBase result = new ResultBase() { };
            BackofficeUser_Manager bm = new BackofficeUser_Manager();
            var user = bm.GetByParameter(new BackofficeUser_Filter()
            {
                UserName = username
            }).FirstOrDefault();
            if (user != null)
            {
                result.setErrorMessage("這個帳號已經註冊過了。");
            }
            else
            {
                bm.Insert(new BackofficeUser_Info()
                {
                    LastUpdator = sessionData.trading.UserName,
                    Level = 1,
                    LoginId = username,
                    Password = password,
                    UserName = username
                });

                MakeTrading(username);
                sessionData.trading.isLogined = true;

                result.setMessage("帳號建立完成。");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult Registry(string username, string password, string TeamGroupID)
        {
            ResultBase result = new ResultBase() { };
            User_Manager um = new User_Manager();
            var user = um.GetByParameter(new User_Filter()
            {
                LoginId = username
            }).FirstOrDefault();
            if (user != null)
            {
                result.setErrorMessage("這個帳號已經註冊過了。");
            }
            else
            {
                int? TeamGroupSN = null;
                if (!string.IsNullOrEmpty(TeamGroupID))
                {
                    TeamGroupSN = Encrypt.GetEncryptTeamGropuSN(TeamGroupID);
                }

                if (TeamGroupSN.HasValue && TeamGroupSN == 0)
                {
                    result.setErrorMessage("您目前所預設加入的群組不存在。");
                }
                else
                {
                    um.Insert(new User_Info()
                    {
                        LoginId = username,
                        Password = password,
                        Status = 1,
                        UserName = username,
                        Picture = "/pic/NoIcon.jpg",
                        TeamGroupSN = TeamGroupSN.HasValue ? TeamGroupSN.Value : 0
                    });

                    MakeTrading(username);
                    sessionData.trading.isLogined = true;

                    result.setMessage("帳號建立完成。");
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult Logout()
        {
            if (sessionData != null && sessionData.trading != null)
            {
                sessionData.Logout();
            }
            ResultBase r = new ResultBase();
            r.setMessage("您已登出。");
            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}