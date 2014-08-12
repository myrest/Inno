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

        public ActionResult Index()
        {
            if (sessionData.trading != null && sessionData.trading.isLogined)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}