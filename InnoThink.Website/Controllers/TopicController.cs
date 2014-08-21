using InnoThink.Core;
using InnoThink.Core.Cache.Board;
using InnoThink.Core.Cache.SignalR;
using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.Model.Topic;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InnoThink.BLL.User;
using InnoThink.Domain;
using InnoThink.Domain.InnoThinkMain.Binding;
using InnoThink.BLL.Topic;
using InnoThink.BLL.TopicMember;

namespace InnoThink.Website.Controllers
{
    public class TopicController : BaseController
    {
        //
        // GET: /Product/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(TopicController));

        private static readonly Topic_Manager dbTopic = new Topic_Manager();
        private static readonly TopicMember_Manager dbTMem = new TopicMember_Manager();
        
        private static readonly TopicMember_Manager dbTopMem = new TopicMember_Manager() { };
        private static readonly DbBestStep1Table dbBest1 = new DbBestStep1Table() { };
        private static readonly DbBestIdeaTable dbBestIdea = new DbBestIdeaTable() { };
        private static readonly DbBestIdeaMemRankTable dbBestIdeaMemRank = new DbBestIdeaMemRankTable() { };
        private static readonly DbBestIdeaGroupTable dbBestIdeaGrp = new DbBestIdeaGroupTable() { };
        private static readonly DbBestIdeaGroupRankTable dbBestGroupRank = new DbBestIdeaGroupRankTable() { };
        private static readonly DbBestGAPTable dbBestGap = new DbBestGAPTable() { };
        private static readonly DbResultsTable dbResult = new DbResultsTable() { };

        public TopicController()
            : base(Permission.Private)
        {
        }

        public static void MakeBoardViewModel(int TopicSN, ViewDataDictionary viewdata, Trading trading, bool isAdmin)
        {
            List<BoardUI> PrivateBoard = BoardCache.GetAllBoard(TopicSN, Domain.Constancy.BoardType.Private);
            List<BoardUI> PublicBoard = BoardCache.GetAllBoard(TopicSN, Domain.Constancy.BoardType.Public);
            var dbTopic = new Topic_Manager();
            var Topic = dbTopic.GetBySN(TopicSN);
            viewdata["IsLeader"] = (string.Compare(trading.LoginId, Topic.LeaderLoginId, true) == 0);
            viewdata["IsClose"] = Topic.DateClosed > DateTime.MinValue;
            viewdata["IsTeamMember"] = dbTMem.IsTeamMember(TopicSN, trading.UserSN);
            viewdata["Subject"] = Topic.Subject;
            viewdata["TopicSN"] = Topic.TopicSN;
            if (isAdmin)
            {
                //Admin can see all the information.
                viewdata["IsTeamMember"] = true;
            }
            viewdata["PrivateBoard"] = PrivateBoard;
            viewdata["PublicBoard"] = PublicBoard;

            //Handle online team member.
            var allmembers = dbTopMem.getALLTopicMember(TopicSN);
            allmembers.ForEach(x => x.Picture = StringUtility.ConvertPicturePath(x.Picture));

            //online member need add self sn on the list
            var allonline = ConnectionManageBase.GetAllOnLineUserSN(TopicSN);
            if (allonline.Where(x => x == trading.UserSN).Count() == 0)
            {
                allonline.Add(trading.UserSN);
            }
            var OnlineTeamMember = allmembers.Where(x => allonline.Contains(x.UserSN)).ToList();
            var OfflineTeamMember = allmembers.Where(x => !allonline.Contains(x.UserSN)).ToList();
            viewdata["OnlineTeamMember"] = OnlineTeamMember;
            viewdata["OfflineTeamMember"] = OfflineTeamMember;
        }

        //第1單元介紹：認識朋友-1
        public ActionResult Step0(int TopicSN)
        {
            MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            Step0ViewModel model = new Step0ViewModel() { };
            List<TopicMemberUI> Step0d = dbTMem.getStep0Description(TopicSN);
            bool IsTeamMember = (bool)ViewData["IsTeamMember"];
            if (IsTeamMember)
            {
                var mySetting = Step0d.Where(x => x.UserSN == sessionData.trading.UserSN).FirstOrDefault();
                if (mySetting != null && mySetting.UserSN > 0)
                {
                    model.LeaderVoteTo = Step0d.Where(x => x.UserSN == sessionData.trading.UserSN).FirstOrDefault().LeaderSNVoteTo;
                    model.MyDescription = Step0d.Where(x => x.UserSN == sessionData.trading.UserSN).FirstOrDefault().Description;
                }
            }
            Step0d.ForEach(x =>
            {
                //Change Picture path.
                x.Picture = StringUtility.ConvertPicturePath(x.Picture);
                //Caculate vote number for each team memeber.
                x.VoteNums = Step0d.Where(y => y.LeaderSNVoteTo == x.UserSN).Count();
            });
            model.TeamMembers = Step0d.ToDictionary(x => x.UserSN);
            model.TopicSN = TopicSN;
            model.Leader = Step0d.Count() > 0 ? Step0d.OrderByDescending(x => x.VoteNums).ThenBy(x => x.UserSN).First().UserName : "";
            ViewData["Model"] = model;
            return View();
        }

        //第1單元介紹：認識朋友-2
        public ActionResult Step1(int TopicSN)
        {
            MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            //Assign sn into session for upload file purpose.
            sessionData.trading._tempInt = TopicSN;

            var Topic = dbTopic.GetBySN(TopicSN);
            Step1ViewModel model = new Step1ViewModel()
            {
                //LeaderName = --Should put Leader's name, here is Leader's login id.
                //TeamMembers = --Should get from topic member
                //LeaderUserSN = --Should get from user object.
                LogoImage = string.Format("<img src=\"{0}\" />", StringUtility.ConvertTeamLogoPath(Topic.LogoImg)),
                Subject = Topic.Subject,
                Target = Topic.Target,
                TeamName = Topic.TeamName,
                TopicSN = TopicSN,
                DateCreated = Topic.DateCreated.ToString("yyyy-MM-dd"),
            };
            User_Manager um = new User_Manager();
            
            var LeaderUser = um.GetByParameter(new User_Filter()
            {
                LoginId = Topic.LeaderLoginId
            }).FirstOrDefault();
            model.LeaderUserSN = LeaderUser.UserSN;
            model.IsLeader = (model.LeaderUserSN == sessionData.trading.UserSN);

            List<TopicMemberUI> Step1d = dbTMem.getStep0Description(TopicSN);

            //Modify each team member information
            Step1d.ForEach(x =>
            {
                //Change Picture path.
                x.Picture = StringUtility.ConvertPicturePath(x.Picture);
                //Caculate vote number for each team memeber.
                x.VoteNums = Step1d.Where(y => y.LeaderSNVoteTo == x.UserSN).Count();
            });
            model.LeaderName = Step1d.OrderByDescending(x => x.VoteNums).ThenBy(x => x.UserSN).First().UserName;
            model.TeamMembers = Step1d.ToDictionary(x => x.UserSN);

            ViewData["Model"] = model;
            return View();
        }

        //結果-草稿
        public ActionResult Result1(int TopicSN)
        {
            //DRAFT, 草稿
            doResultView(TopicSN, ResultType.DRAFT);
            return View();
        }

        //結果-表板
        public ActionResult Result2(int TopicSN)
        {
            //DASHBOARD, 表板
            doResultView(TopicSN, ResultType.DASHBOARD);
            return View();
        }

        //結果-發表
        public ActionResult Result3(int TopicSN)
        {
            //PRESENTATION, 發表
            doResultView(TopicSN, ResultType.PRESENTATION);
            return View();
        }

        public void doResultView(int TopicSN, ResultType Result)
        {
            MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
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

        //Best分析法1
        public ActionResult Best1(int TopicSN)
        {
            MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();
            Best1ViewModel Model = new Best1ViewModel() { };
            var list = dbBest1.GetAllByTopicSN(TopicSN);
            //Change image path.
            list.ForEach(x =>
            {
                x.Image = StringUtility.ConvertBestPath(x.Image);
            });

            Model.Listing = list;
            Model.TopicSN = TopicSN;
            ViewData["Model"] = Model;
            return View();
        }

        //Best分析法2
        public ActionResult Best2(int TopicSN)
        {
            MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();
            Best2ViewModel Model = new Best2ViewModel() { };
            var list = dbBestIdea.GetAllByTopicSN(TopicSN);
            Model.Listing = list;
            Model.TopicSN = TopicSN;
            ViewData["Model"] = Model;
            return View();
        }

        //Best分析法3
        public ActionResult Best3(int TopicSN)
        {
            MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();
            Best3ViewModel Model = new Best3ViewModel() { };
            var list = dbBestIdeaMemRank.GetAllByTopicSN(TopicSN, sessionData.trading.UserSN);
            Model.Listing = list;
            Model.TopicSN = TopicSN;
            ViewData["Model"] = Model;
            return View();
        }

        //Best分析法4
        public ActionResult Best4(int TopicSN)
        {
            MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();
            Best4ViewModel Model = new Best4ViewModel() { };
            var list = dbBestIdea.GetAllViewDataByTopicSN(TopicSN);
            var GroupList = dbBestIdeaGrp.GetALLByTopicSN(TopicSN);
            if (GroupList == null)
            {
                GroupList = new List<DbBestIdeaGroup>() { };
            }
            Model.Listing = list;
            Model.GroupListing = GroupList;
            Model.TopicSN = TopicSN;
            ViewData["Model"] = Model;
            return View();
        }

        //Best分析法5
        public ActionResult Best5(int TopicSN)
        {
            MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();
            Best5ViewModel Model = new Best5ViewModel() { };
            var list = dbBestGroupRank.GetAllByTopicSN(TopicSN, sessionData.trading.UserSN);
            Model.Listing = list;
            Model.TopicSN = TopicSN;
            ViewData["Model"] = Model;
            return View();
        }

        //Best分析法6
        public ActionResult Best6(int TopicSN)
        {
            MakeBoardViewModel(TopicSN, ViewData, sessionData.trading, isAdmin);
            sessionData.ClearTempValue();

            //Get IdeaGroup information for list donw check box
            Best6ViewModel GroupModel = new Best6ViewModel() { };
            List<DbBest6DataModel> listBest5 = dbBestIdeaGrp.GetAllViewDataByTopicSN(TopicSN);
            GroupModel.Listing = listBest5;
            GroupModel.TopicSN = TopicSN;

            var list = dbBestGap.GetALLByTopicSN(TopicSN);
            //Change image path.
            if (list != null)
            {
                list.ForEach(x =>
                {
                    x.Document = StringUtility.ConvertGAPPath(x.Document);
                });
            }
            else
            {
                list = new List<DbBestGAPModel>() { };
            }

            GroupModel.GAPListing = list;
            ViewData["Model"] = GroupModel;
            return View();
        }
    }
}