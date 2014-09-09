using System.Web.Mvc;
using InnoThink.Core.Constancy;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Domain.Constancy;
using Rest.Core.Utility;

namespace InnoThink.Website.Controllers
{
    /// <summary>
    /// Likert scale
    /// </summary>
    public class LikertScaleController : BaseController
    {
        //
        // GET: /Scenario/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(LikertScaleController));

        public LikertScaleController()
            : base(Permission.Private)
        {
            sessionData.ClearTempValue();
        }

        //4 items and 5 level point
        public ActionResult LikertScale1(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            //Get rank for LSType


            /*
            var UIObj = new AnalysisUIFormObject()
            {
                MainFunction ="分組與初探",
                TitleLeft = "現有市場描述",
                TitleRight = "親身體驗服務",
                TypeLeft = (int)EnumAnalysisType.CurrentMarket,
                TypeRight = (int)EnumAnalysisType.Visit
            };
            ViewData["TopicSN"] = TopicSN;
            ViewData["FormUI"] = UIObj;
            */
            return View();
        }

    }
}