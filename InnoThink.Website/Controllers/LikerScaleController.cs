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
using InnoThink.BLL.InnoThinkMain.Binding;

namespace InnoThink.Website.Controllers
{
    public class LikerScaleController : BaseController
    {
        private static readonly SysLog Log = SysLog.GetLogger(typeof(LikerScaleController));

        private static readonly LikerScaleBindingBLL lsbind = new LikerScaleBindingBLL();

        public LikerScaleController()
            : base(Permission.Private)
        {
        }


        //現有市場描述及親身體驗服務
        public ActionResult LikerScale1(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();

            List<LikerScaleBindingView> result = lsbind.GetUserRankByType(TopicSN, sessionData.trading.UserSN, EnumLikertScaleType.Analysis1);

            ViewData["TopicSN"] = TopicSN;
            ViewData["Model"] = result;
            return View();
        }
    }
}