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
using InnoThink.BLL.BackofficeUser;

namespace InnoThink.Website.Controllers
{
    public class AdminController : BaseController
    {
        //
        // GET: /Product/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AdminController));

        private static readonly TeamGroup_Manager dbTG = new TeamGroup_Manager() { };

        public AdminController()
            : base(Permission.Admin)
        {
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult AdminListing()
        {
            BackofficeUser_Manager bm = new BackofficeUser_Manager();
            var result  = bm.GetAll().ToList();
            ViewData["Model"] = result;
            return View();
        }

        public ActionResult AdminEdit(int SN)
        {
            BackofficeUser_Info result = new BackofficeUser_Info() { };
            if (SN > 0)
            {
                //edit
                result = new BackofficeUser_Manager().GetBySN(SN);
            }
            ViewData["Model"] = result;
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
                var TeamGroupList = dbTG.GetAll().ToList();
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
                var tg = dbTG.GetBySN(SN);

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