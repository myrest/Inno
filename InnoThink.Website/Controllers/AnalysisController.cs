using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InnoThink.Domain;
using InnoThink.Domain.InnoThinkMain.Binding;
using InnoThink.Domain.Constancy;
using InnoThink.BLL.Analysis;

namespace InnoThink.Website.Controllers
{
    public class AnalysisController : BaseController
    {
        //
        // GET: /Scenario/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AnalysisController));

        public AnalysisController()
            : base(Permission.Private)
        {
        }

        //現有市場描述
        public ActionResult Analysis1(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();
            Analysis_Manager am = new Analysis_Manager();
            var list = am.GetByTopicSN(TopicSN, EnumAnalysisType.CurrentMarket);
            //Change image path.
            list.ForEach(x =>
            {
                x.ServerFileName = StringUtility.ConvertResultPath(x.ServerFileName);
            });
            ViewData["Model"] = list;
            ViewData["TopicSN"] = TopicSN;
            return View();
        }
    }
}