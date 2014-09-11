using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using InnoThink.Core.Constancy;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Domain.InnoThinkMain.Binding;
using InnoThink.Website.Controllers.Service;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using Newtonsoft.Json;
using InnoThink.Domain.Constancy;
using System;
using InnoThink.BLL.LikertScale;

namespace EShopManager.Website.Controllers.Service
{
    public class LikerScaleServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(LikerScaleServiceController));
        private static readonly LikertScale_Manager lsManage = new LikertScale_Manager();


        public LikerScaleServiceController()
            : base(Permission.Private)
        {
        }

        [HttpPost]
        public JsonResult UpdateLikerScaleRank(string Ranks)
        {
            ResultBase result = new ResultBase() { };
            var AllRank = JsonConvert.DeserializeObject<List<string>>(Ranks);
            List<LikerScaleBatchUpdateObject> para = new List<LikerScaleBatchUpdateObject>() { };
            AllRank.ForEach(x =>
            {
                var RankArr = x.Split(new char[] { '-' }, 3);
                //RankArr[0] : CategoryId
                //RankArr[1] : SN
                //RankArr[2] : Rank
                para.Add(new LikerScaleBatchUpdateObject()
                {
                    LSType = EnumLikertScaleType.Analysis1,
                    ParentSN = Convert.ToInt32(RankArr[1]),
                    Rank = Convert.ToInt32(RankArr[2]),
                    UserSN = sessionData.trading.UserSN
                });
            });

            if (lsManage.InsertBatch(para))
            {
                result.setMessage("Done");
            }
            else
            {
                result.setException("Insert Data Got error.", "UpdateLikerScaleRank");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
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
