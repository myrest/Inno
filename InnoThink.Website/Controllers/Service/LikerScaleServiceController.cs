using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using InnoThink.Core.Constancy;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Domain.InnoThinkMain.Binding;
using InnoThink.Website.Controllers.Service;
using InnoThink.Website.Models;
using Rest.Core.Utility;

namespace EShopManager.Website.Controllers.Service
{
    public class LikerScaleServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(LikerScaleServiceController));

        public LikerScaleServiceController()
            : base(Permission.Private)
        {
        }

        #region Switch Step
        [HttpPost]
        public JsonResult GotoLikerScale1(int TopicSN)
        {
            return _GotoStep(TopicSN, 60);
        }

        private JsonResult _GotoStep(int TopicSN, int step)
        {
            int GotoStep = step;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            //Get all team member vote for leader.
            List<TopicMemberUI> OutTeamMembers = new List<TopicMemberUI>() { };
            result = TopicServiceController.ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out OutTeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }
        #endregion
    }
}
