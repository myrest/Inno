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
        public JsonResult Registry(string username, string password)
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
                um.Insert(new User_Info()
                {
                    LoginId = username,
                    Password = password,
                    Status = 1,
                    UserName = username,
                    Picture = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcT1kUj3CKnEap-jazJzzVSOH6e8eWH5fGoiqVNF_lRlv0s8Kzt2Mg"
                });

                MakeTrading(username);
                sessionData.trading.isLogined = true;

                result.setMessage("帳號建立完成。");
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