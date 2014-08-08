using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System;
using System.Web.Mvc;

namespace InnoThink.Website.Controllers
{
    public class MemberController : BaseController
    {
        //
        // GET: /Product/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(MemberController));

        private static readonly DbTopicTable dbTopic = new DbTopicTable() { };
        private static readonly DbUserTable dbUser = new DbUserTable() { };
        private static readonly DbTopicMemberTable dbTopicMem = new DbTopicMemberTable() { };

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
            DbUserModel user = dbUser.getUserBySN(sessionData.trading.sn);
            //check the personal icon is come from out site link.
            user.Picture = StringUtility.ConvertPicturePath(user.Picture);

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
                var user = dbUser.getUserBySN(sessionData.trading.sn);
                if (isAdmin)
                {
                    model.DBResult = dbTopic.GetAllTopic_Admin();
                }
                else
                {
                    model.DBResult = dbTopic.GetAllTopicByStatus(TopicStatus.InProcess, user.TeamGroupSN, sessionData.trading.LoginId);
                }
                model.JoinedTopic = dbTopicMem.GetAllJoinedTopicByUserSN(sessionData.trading.sn);

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
                model.DBResult = dbTopic.GetAllMyTopicByStatus(TopicStatus.InProcess, sessionData.trading.sn);
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