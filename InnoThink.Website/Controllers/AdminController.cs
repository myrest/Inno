using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System;
using System.Linq;
using System.Web.Mvc;
using InnoThink.BLL.User;
using InnoThink.Domain;
using InnoThink.BLL.TeamGroup;

namespace InnoThink.Website.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Product/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AdminController));



        private static readonly TeamGroup_Manager dbTG = new TeamGroup_Manager() { };

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

                User_Manager um = new User_Manager();
                var users = um.GetByParameter(new User_Filter()
                {
                    TeamGroupSN = SN
                }).ToList();
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