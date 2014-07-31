using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopManager.Core.MVC.BaseController;
using EShopManager.Core.Utility;
using EShopManager.Core.Constancy;
using EShopManager.Website.Models;
using EShopManager.Core.DB;
using CWB.Web.Configuration;

namespace EShopManager.Website.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Product/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AdminController));
        private static readonly DbTopicTable dbTopic = new DbTopicTable() { };
        private static readonly DbUserTable dbUser = new DbUserTable() { };
        private static readonly DbTeamGroupTable dbTG = new DbTeamGroupTable() { };

        public AdminController()
            : base(Permission.Private)
        {

        }

        public ActionResult AdjustUserPosition()
        {
            return View();
        }

        public ActionResult CreateTeamGroup()
        {
            return View();
        }

        public ActionResult TeamGroupListing()
        {
            TeamGroupListViewModel model = new TeamGroupListViewModel();
            try
            {
                var TeamGroupList = dbTG.getAllTeamGroup();
                model.DataResult = TeamGroupList;
                model.JsonReturnCode = 1;
            }
            catch (Exception ex)
            {
                model.setException(ex, "TeamGroupListing");
            }
            ViewData["Model"] = model;
            return View();
        }

        public ActionResult TeamGroupMemberListing(int SN)
        {
            UsersViewModel model = new UsersViewModel() { };
            try
            {
                var tg = dbTG.getTeamGroupBySN(SN);
                var users = dbUser.GetUserByTeamGroupSN(SN);
                model.TeamGroupName = tg.GroupName;
                model.TeamGroupSN = SN;
                model.DataResult = users;
                model.JsonReturnCode = 1;
            }
            catch (Exception ex)
            {
                model.setException(ex, "TeamGroupMemberListing");
            }
            ViewData["Model"] = model;
            return View();
        }
    }
}
