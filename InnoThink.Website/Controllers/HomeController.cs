using InnoThink.Core.Constancy;
using InnoThink.Core.MVC.BaseController;
using Rest.Core.Utility;
using System.Web.Mvc;
using System.Net;

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
            string FBGroupID = string.Empty;
            ViewData["FBToken"] = sessionData.trading.FBAccessToken;
            string hostname = HttpContext.Request.Url.Host;
            if (hostname.ToLower().Contains("www.innoroot.com"))
            {
                //FBGroupID = "1465916723672476";//2014實務專題討論
                FBGroupID = "1055290374511536";//北科大104年進修工業設計-實務專題
            }
            else
            {
                FBGroupID = "536281986502720";//innoroot
            }
            ViewData["FBGroupID"] = FBGroupID;

            return View();
        }
    }
}