using InnoThink.Core.Constancy;
using InnoThink.Core.MVC.BaseController;
using Rest.Core.Utility;
using System.Web.Mvc;

namespace InnoThink.Website.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Product/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(HomeController));

        public HomeController()
            : base(Permission.Private)
        {
        }

        public ActionResult Index()
        {
            ViewData["FBToken"] = sessionData.trading.FBAccessToken;
            return View();
        }
    }
}