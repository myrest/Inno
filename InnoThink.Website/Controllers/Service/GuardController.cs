using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnoThink.Core.MVC.BaseController;
using Rest.Core.Utility;
using InnoThink.Core.Constancy;
using System.Web.Routing;

namespace EShopManager.Website.Controllers.Service
{
    public class GuardController : BaseController
    {
        //
        // GET: /Default/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(GuardController));

        public GuardController()
            : base(Permission.Public)
        {
        }

        public ActionResult Check(string ID)
        {
            if (ID == "Admin")
            {
                if (sessionData.trading != null && sessionData.trading.isLogined)
                {
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    return RedirectToAction("Admin", "Default");
                }
            }
            else
            {
                if (sessionData.trading != null && sessionData.trading.isLogined)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    int TeamGroupSN = Encrypt.GetEncryptTeamGropuSN(ID);
                    if (TeamGroupSN == 0)
                    {
                        return RedirectToAction("Index", "Default");
                    }
                    else
                    {
                        ViewData["TopicGroupId"] = ID;
                        return View(@"~\Views\Default\Index.aspx");
                    }
                }
            }
        }
    }
}
