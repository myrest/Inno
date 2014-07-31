using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopManager.Core.MVC.BaseController;
using EShopManager.Core.Utility;
using EShopManager.Core.Constancy;

namespace EShopManager.Website.Controllers
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
            return View();
        }

    }
}
