using System.Web.Mvc;
using InnoThink.Core.MVC.BaseController;
using Rest.Core.Utility;
using InnoThink.Core.Constancy;

namespace InnoThink.Website.Controllers
{
    public class DefaultController : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(HomeController));

        public DefaultController()
            : base(Permission.Public)
        {
        }

        public ActionResult Index(string id)
        {
            if (sessionData.trading != null && sessionData.trading.isLogined)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (string.IsNullOrEmpty(id))
                {
                    ViewData["TopicGroupId"] = "";
                }
                else
                {
                    ViewData["TopicGroupId"] = id;
                }
                return View();
            }
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}