using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System;
using System.Web.Mvc;
using InnoThink.BLL.User;
using InnoThink.Domain;
using InnoThink.BLL.Topic;
using InnoThink.Domain.Constancy;
using InnoThink.BLL.TopicMember;

namespace InnoThink.Website.Controllers
{
    public class MemberController : BaseController
    {
        //
        // GET: /Product/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(MemberController));

        private static readonly Topic_Manager dbTopic = new Topic_Manager();

        private static readonly TopicMember_Manager dbTopMem = new TopicMember_Manager() { };

        public MemberController()
            : base(Permission.Private)
        {
        }

        public ActionResult UserInfo()
        {
            return View();
        }

        public ActionResult ChangePassowrd()
        {
            return View();
        }

        public ActionResult UpdateMyInfo()
        {
            User_Manager um = new User_Manager();
            var user = um.GetBySN(sessionData.trading.ReallUserSN);
            //check the personal icon is come from out site link.
            user.Picture = StringUtility.ConvertPicturePath(user.Picture);
            ViewData["TeamGroupID"] = Encrypt.EncryptTeamGroupSN(user.TeamGroupSN);
            ViewData["Model"] = user;
            return View();
        }

        public ActionResult CreateNewTopic()
        {
            return View();
        }

        //建立新的議題
        public ActionResult NewTopicListing()
        {
            TopicSimpleViewModel model = new TopicSimpleViewModel();
            try
            {
                User_Manager um = new User_Manager();
                var user = um.GetBySN(sessionData.trading.UserSN);
                model.DBResult = dbTopic.GetAllTopicByStatus(TopicStatus.InProcess, user.TeamGroupSN);
                model.JoinedTopic = dbTopMem.GetAllJoinedTopicByUserSN(sessionData.trading.UserSN);

                model.JsonReturnCode = 1;
            }
            catch (Exception ex)
            {
                model.setException(ex, "NewTopicListing");
            }
            ViewData["Model"] = model;
            return View();
        }

        //正在參加的議題
        public ActionResult JoinedTopic()
        {
            TopicSimpleViewModel model = new TopicSimpleViewModel();
            try
            {
                model.DBResult = dbTopic.GetAllMyTopicByStatus(TopicStatus.InProcess, sessionData.trading.UserSN);
                model.JsonReturnCode = 1;
            }
            catch (Exception ex)
            {
                model.setException(ex, "JoinedTopic");
            }
            ViewData["Model"] = model;
            return View();
        }
    }
}