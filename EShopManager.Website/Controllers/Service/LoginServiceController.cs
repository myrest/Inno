using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopManager.Core.Utility;
using EShopManager.Core.DB;
using EShopManager.Website.Models;
using CWB.Web;
using CWB.Web.Configuration;
using EShopManager.Core.Constancy;
using EShopManager.Core;
using EShopManager.Core.MVC.BaseController;
using EShopManager.Core.Model;
using EShopManager.Core.Cache.SignalR;
using EShopManager.Website.Communication;

namespace EShopManager.Website.Controllers.Service
{
    public class LoginServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(LoginServiceController));
        private static readonly DbUserTable dbUser = new DbUserTable() { };

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
            var user = dbUser.getUserByLoginId(LoginId);
            trading.LoginId = LoginId;
            trading.Picture = user.Picture;
            trading.UserName = user.UserName;
            trading.sn = user.SN;
            trading.Position = user.Position;
            sessionData.trading = trading;
        }

        [HttpPost]
        public JsonResult FBLogin(string token)
        {
            ResultBase result = new ResultBase();
            sessionData.trading = new Trading();
            FacebookPersonAuth FBObject = FBUtility.GetUserID(token);
            if (dbUser.FBLoginCheck(FBObject))
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
            if (sessionData.trading != null && sessionData.trading.sn > 0)
            {
                ConnectionManageBase.Update(ConnectionId, sessionData.trading.sn);
            }
            //Sync all the team member at the same TopicSN
            DbUserModel user = dbUser.getUserBySN(sessionData.trading.sn);
            user.Picture = StringUtility.ConvertPicturePath(user.Picture);
            var cacheobj = ConnectionManageBase.GetByUserSN(sessionData.trading.sn);
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
                    if (dbUser.isPasswordCorrect(username, password))
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
            bool userIsExist = dbUser.CheckIdIsExist(username);
            ResultBase result = new ResultBase() { };
            if (userIsExist)
            {
                result.setException(new Exception("這個帳號已經註冊過了。"), "Registry");
            }
            else
            {
                dbUser.AddNewUser(new DbUserModel()
                {
                    LoginId = username,
                    Password = password,
                    Status = 1,
                    Position = 1,
                    UserName = username
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
