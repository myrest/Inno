using CWB.Web.Configuration;
using InnoThink.Core.Constancy;
using InnoThink.Core.MVC.ReturnResult;
using Rest.Core.Utility;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace InnoThink.Core.MVC.BaseController
{
    public class BaseController : Controller
    {
        private static readonly SysLog Log = SysLog.GetLogger(typeof(BaseController));

        protected Permission ControllerPermision { get; set; }

        protected bool isAdmin = false;
        protected bool isSys = false;

        protected SessionData sessionData = new SessionData();

        protected BaseController(Permission permission)
        {
            ControllerPermision = permission;
            if (sessionData != null && sessionData.trading != null)
            {
                isAdmin = sessionData.trading.Level > 0;
                isSys = sessionData.trading.Level > 0;
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
                ViewData["_UserSN"] = sessionData.trading.UserSN;
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
                    if (ControllerPermision == Permission.Admin && sessionData.trading.Level < 1)
                    {
                        Log.Debug("Permission Deny");
                        RejectRequestResult.RejectRequest(filterContext, RejectReason.PermissionDeny, sessionData);
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