﻿using System.Text;
using System.Web.Mvc;
using InnoThink.Core.MVC;
using InnoThink.Core.Utility;
using InnoThink.Core;
using System.Web;
using CWB.Web.Configuration;
using InnoThink.Core.Constancy;
using InnoThink.Core.MVC.ReturnResult;
using Rest.Core.Utility;

namespace InnoThink.Core.MVC.BaseController
{
    public class BaseController : Controller
    {
        private static readonly SysLog Log = SysLog.GetLogger(typeof(BaseController));
        protected Permission ControllerPermision { get; set; }
        protected bool isAdmin = false;
        protected bool isSys = false;
        private readonly string Admins = "royadmin";

        protected SessionData sessionData = new SessionData();

        protected BaseController(Permission permission)
        {
            ControllerPermision = permission;
            if (ControllerPermision == Permission.Private && sessionData != null && sessionData.trading != null)
            {
                isAdmin = sessionData.trading.Position == 11 || Admins.Contains(sessionData.trading.LoginId);
                isSys = sessionData.trading.Position == 111 || Admins.Contains(sessionData.trading.LoginId);
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = Json("Got Server Error, Please check with Administrator. Thansk!", JsonRequestBehavior.AllowGet);
            filterContext.ExceptionHandled = true;
            Log.Exception(filterContext.Exception);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            //add P3P header to make sure the pages inside other frames able to use cookies
            filterContext.HttpContext.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            throw new HttpException(404, "");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetOmitVaryStar(true);
            ViewData["_v"] = AppConfigManager.SystemSetting.StaticFileVersionNumber;
            if (sessionData != null && sessionData.trading != null && sessionData.trading.isLogined)
            {
                ViewData["_UserSN"] = sessionData.trading.sn;
                ViewData["_isAdmin"] = isAdmin;
                ViewData["_isSys"] = isSys;
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (ControllerPermision != Permission.Public)
            {
                if (sessionData.trading != null)
                {
                    if (!sessionData.trading.isLogined)
                    {
                        Log.Debug("Session Lost");
                        RejectRequestResult.RejectRequest(filterContext, RejectReason.SessionLost, sessionData);
                    }
                }
                else
                {
                    Log.Debug("Session Lost");
                    RejectRequestResult.RejectRequest(filterContext, RejectReason.SessionLost, sessionData);
                }
            }
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonDataContractResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}