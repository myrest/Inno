using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System.Web.Mvc;
using InnoThink.BLL.User;
using System.Linq;
using InnoThink.Domain;
using InnoThink.BLL.TeamGroup;
using System;
using InnoThink.BLL.BackofficeUser;
using System.Collections.Generic;

namespace InnoThink.Website.Controllers.Service
{
    public class AdminServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AdminServiceController));

        
        private static readonly DbTopicMemberTable dbTopMem = new DbTopicMemberTable() { };

        private static readonly TeamGroup_Manager dbTgroup = new TeamGroup_Manager();

        public AdminServiceController()
            : base(Permission.Admin)
        {
        }

        [HttpPost]
        public JsonResult AdjustUserPosition(string LoginId, int Level, int SN, string Password)
        {
            ResultBase result = new ResultBase() { };
            var bm = new BackofficeUser_Manager();
            if (SN > 0)
            {
                //edit
                var data = bm.GetBySN(SN);
                data.Level = Level;
                List<string> columns = new List<string>()
                {
                    "Level"
                };
                if (!string.IsNullOrEmpty(Password))
                {
                    data.Password = Password;
                    columns.Add("Password");
                }
                bm.Update(data.BackofficeUserSN, data, columns);
                result.setMessage("Done");
            }
            else
            {
                //check is loginid has been used.
                var data = bm.GetByParameter(new BackofficeUser_Filter()
                {
                    LoginId = LoginId
                }).FirstOrDefault();
                if (data != null)
                {
                    result.setErrorMessage(string.Format("帳號{0}已經有人使用。", LoginId));
                }
                else
                {
                    //insert
                    data = new BackofficeUser_Info()
                    {
                        LastUpdator = sessionData.trading.LoginId,
                        Level = Level,
                        LoginId = LoginId,
                        Password = Password,
                        UserName = LoginId
                    };
                    bm.Insert(data);
                    result.setMessage("Done");
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteAdmin(int SN)
        {
            ResultBase result = new ResultBase() { };
            if (SN > 0)
            {
                var bm = new BackofficeUser_Manager();
                bm.Delete(SN);
            }
            result.setMessage("Done");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult CreateTeamGroup(string TeamGroupName)
        {
            ResultBase result = new ResultBase() { };
            //Chcek has the same name.
            var isExist = dbTgroup.CheckNameIsExist(TeamGroupName);
            if (!isExist)
            {
                var data = new TeamGroup_Info()
                {
                    GroupName = TeamGroupName,
                    LastUpdate = DateTime.Now,
                     MaxUsers = 99
                };
                dbTgroup.Insert(data);
                result.setMessage(string.Format("團隊名稱[{0}]，建立完成。", TeamGroupName));
            }
            else
            {
                result.setErrorMessage("相同名稱已存在。");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult AddTeamGroupMember(string LoginId, int TeamGroupSN)
        {
            ResultBase result = new ResultBase() { };
            User_Manager um = new User_Manager();
            var user = um.GetByParameter(new User_Filter()
            {
                LoginId = LoginId
            }).FirstOrDefault();
            if (user != null && user.UserSN > 0 && user.TeamGroupSN == 0)
            {
                user.TeamGroupSN = TeamGroupSN;
                um.Update(user.UserSN, user, new string[] { "*" });
                result.setMessage(string.Empty);
            }
            else
            {
                if (user.TeamGroupSN == TeamGroupSN && user.UserSN > 0)
                {
                    result.setErrorMessage("該成員已是本團隊成員之一。");
                }
                else if (user.TeamGroupSN > 0 && user.UserSN > 0)
                {
                    var tg = dbTgroup.GetBySN(user.TeamGroupSN);
                    result.setErrorMessage(string.Format("該成員已加入[{0}]團隊，請先退出該團隊後再加入。", tg.GroupName));
                }
                else
                {
                    result.setErrorMessage("該帳號不存在");
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteTeamGroupMember(int SN)
        {
            ResultBase result = new ResultBase() { };
            User_Manager um = new User_Manager();
            var user = um.GetBySN(sessionData.trading.UserSN);
            if (user != null && user.UserSN > 0)
            {
                user.TeamGroupSN = 0;
                um.Update(user);
                result.setMessage(string.Empty);
            }
            else
            {
                result.setErrorMessage("該帳號不存在");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}