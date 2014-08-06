using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Core.Constancy;
using Rest.Core.Utility;

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
            return View();
        }

    }
}
