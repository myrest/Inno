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

namespace InnoThink.Website.Controllers
{
    public class ScenarioController : BaseController
    {
        //
        // GET: /Scenario/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(TopicController));

        
        
        private static readonly DbResultsTable dbResult = new DbResultsTable() { };
        private static readonly DbScenarioTable dbScenario = new DbScenarioTable() { };

        public ScenarioController()
            : base(Permission.Private)
        {
        }

        public void doResultView(int TopicSN, ResultType Result)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();
            ResultViewModel Model = new ResultViewModel() { };
            var list = dbResult.GetAllByTopicSN(TopicSN, Result, sessionData.trading.UserSN);
            //Change image path.
            list.ForEach(x =>
            {
                x.ServerFileName = StringUtility.ConvertResultsPath(x.ServerFileName);
            });

            Model.Listing = list;
            Model.TopicSN = TopicSN;
            ViewData["Model"] = Model;
        }

        //情境分析法1
        public ActionResult Scenario1(int TopicSN)
        {
            //情境分析法1
            doResultView(TopicSN, ResultType.SCENARIO_1);
            return View();
        }

        //情境分析法3
        public ActionResult Scenario3(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();

            //Get ScenarioChar infor
            ScenarioCharViewModel Model = new ScenarioCharViewModel(sessionData.trading.UserSN) { };
            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.FirstTime);
            if (list != null)
            {
                //Change image path.
                list.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertScenarioPath(x.ServerFileName);
                });
            }
            Model.Listing = list;
            Model.TopicSN = TopicSN;

            //Get Team member List
            var OnLineMem = (List<TopicMember_Info>)ViewData["OnlineTeamMember"];
            var OffLineMem = (List<TopicMember_Info>)ViewData["OfflineTeamMember"];
            List<TopicMember_Info> AllMember = new List<TopicMember_Info>() { };
            if (OnLineMem != null)
            {
                OnLineMem.ForEach(x => AllMember.Add(x));
            }
            if (OffLineMem != null)
            {
                OffLineMem.ForEach(x => AllMember.Add(x));
            }

            //Make ViewData
            ViewData["Model"] = Model;
            ViewData["AllMember"] = AllMember;

            return View();
        }

        //情境分析法2
        public ActionResult Scenario2(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();
            ScenarioCharViewModel Model = new ScenarioCharViewModel(sessionData.trading.UserSN) { };
            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.FirstTime);
            if (list != null)
            {
                //Change image path.
                list.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertScenarioPath(x.ServerFileName);
                });
            }

            Model.Listing = list;
            Model.TopicSN = TopicSN;
            ViewData["Model"] = Model;

            return View();
        }

        //情境分析法4
        public ActionResult Scenario4(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();

            //Get Team member List
            var OnLineMem = (List<TopicMember_Info>)ViewData["OnlineTeamMember"];
            var OffLineMem = (List<TopicMember_Info>)ViewData["OfflineTeamMember"];
            List<TopicMember_Info> AllMember = new List<TopicMember_Info>() { };
            if (OnLineMem != null)
            {
                OnLineMem.ForEach(x => AllMember.Add(x));
            }
            if (OffLineMem != null)
            {
                OffLineMem.ForEach(x => AllMember.Add(x));
            }

            //Make ViewData
            ViewData["AllMember"] = AllMember;

            return View();
        }

        //情境分析法5
        public ActionResult Scenario5(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();

            //miss username for result.
            List<ScenarioCharValueRankUI> result = dbScenario.GetRankByUserSN(TopicSN, ScenarioType.FirstTime, sessionData.trading.UserSN);
            //Get all the char for vote.
            List<ScenarioCharValueRankUI> resultChar = dbScenario.GetCharRankByTopic(TopicSN, ScenarioType.FirstTime, sessionData.trading.UserSN);
            if (resultChar != null)
            {
                result.Add(new ScenarioCharValueRankUI()
                {
                    Subject = "誰的情境故事最有價值",
                    Values = resultChar.First().Values
                });
            }
            ViewData["Rank"] = result;
            return View();
        }

        //情境分析法6
        public ActionResult Scenario6(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();

            //Build Char setting
            ScenarioCharViewModel Model = new ScenarioCharViewModel(sessionData.trading.UserSN) { };
            //Need to get all the rank for the each char.
            var charRank = dbScenario.GetCharAvgRankByTopic(TopicSN, ScenarioType.FirstTime);
            var charValueRank = dbScenario.GetCharValueAvgRankByTopic(TopicSN, ScenarioType.FirstTime);
            List<ScenarioRankModel> AllRank = new List<ScenarioRankModel>() { };
            if (charRank != null)
            {
                AllRank.AddRange(charRank);
            }
            if (charValueRank != null)
            {
                AllRank.AddRange(charValueRank);
            }

            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.SecondTime);
            if (list != null)
            {
                //Change image path.
                list.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertScenarioPath(x.ServerFileName);
                });
            }

            Model.Listing = list;
            Model.TopicSN = TopicSN;
            ViewData["Model"] = Model;
            ViewData["Rank"] = AllRank;

            return View();
        }

        //情境分析法7
        public ActionResult Scenario7(int TopicSN)
        {
            TopicController.MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();

            //Get ScenarioChar infor
            ScenarioCharViewModel Model = new ScenarioCharViewModel(sessionData.trading.UserSN) { };
            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.SecondTime);
            if (list != null)
            {
                //Change image path.
                list.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertScenarioPath(x.ServerFileName);
                });
            }
            Model.Listing = list;
            Model.TopicSN = TopicSN;

            //Get Team member List
            var OnLineMem = (List<TopicMember_Info>)ViewData["OnlineTeamMember"];
            var OffLineMem = (List<TopicMember_Info>)ViewData["OfflineTeamMember"];
            List<TopicMember_Info> AllMember = new List<TopicMember_Info>() { };
            if (OnLineMem != null)
            {
                OnLineMem.ForEach(x => AllMember.Add(x));
            }
            if (OffLineMem != null)
            {
                OffLineMem.ForEach(x => AllMember.Add(x));
            }

            //Make ViewData
            ViewData["Model"] = Model;
            ViewData["AllMember"] = AllMember;

            return View();
        }
    }
}