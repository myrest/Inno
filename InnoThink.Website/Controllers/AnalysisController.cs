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

        public class AnalysisUIFormObject
        {
            public string TitleLeft { get; set; }
            public string TitleRight { get; set; }
            public int TypeLeft { get; set; }
            public int TypeRight { get; set; }
        }

        //現有市場描述及親身體驗服務
        public ActionResult Analysis1(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();

            var UIObj = new AnalysisUIFormObject()
            {
                TitleLeft = "現有市場描述",
                TitleRight = "親身體驗服務",
                TypeLeft = (int)EnumAnalysisType.CurrentMarket,
                TypeRight = (int)EnumAnalysisType.Visit
            };

            ViewData["TopicSN"] = TopicSN;
            ViewData["FormUI"] = UIObj;
            return View();
            //return View(@"~\Views\Default\Index.aspx");
        }

        //現有功能分析與現有需求分析
        public ActionResult Analysis2(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();

            var UIObj = new AnalysisUIFormObject()
            {
                TitleLeft = "現有功能分析",
                TitleRight = "現有需求分析",
                TypeLeft = (int)EnumAnalysisType.CurrentFuntional,
                TypeRight = (int)EnumAnalysisType.RequestAnalytics
            };

            ViewData["TopicSN"] = TopicSN;
            ViewData["FormUI"] = UIObj;
            return View(@"~\Views\Analysis\Analysis1.aspx");
        }
    }
}