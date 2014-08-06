using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnoThink.Core.Utility;
using InnoThink.Core.DB;
using InnoThink.Website.Models;
using CWB.Web;
using CWB.Web.Configuration;
using InnoThink.Core.Constancy;
using InnoThink.Core;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Website.Models.Topic;
using InnoThink.Website.Communication;
using InnoThink.Core.Model.Topic;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using Rest.Core.Utility;

namespace InnoThink.Website.Controllers.Service
{
    public class AdminServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AdminServiceController));
        private static readonly DbTopicTable dbTopic = new DbTopicTable() { };
        private static readonly DbTopicMemberTable dbTopMem = new DbTopicMemberTable() { };
        private static readonly DbUserTable dbUser = new DbUserTable() { };
        private static readonly DbTeamGroupTable dbTgroup = new DbTeamGroupTable() { };

        public AdminServiceController()
            : base(Permission.Private)
        {
        }

        [HttpPost]
        public JsonResult AdjustUserPosition(string UserLoginId, int Position)
        {
            ResultBase result = new ResultBase() { };
            var user = dbUser.getUserByLoginId(UserLoginId);
            if (user != null && user.SN > 0)
            {
                user.Position = Position;
                dbUser.UpdateUserInfo(user);
                result.setMessage("權限己調整，請該使用者重新登入，以取得新的權限。");
            }
            else
            {
                result.setErrorMessage("該使用者不存在，請輸入正確的使用者登入帳號。");
            }
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
                dbTgroup.AddNewGroupName(TeamGroupName);
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
            var user = dbUser.getUserByLoginId(LoginId);
            if (user != null && user.SN > 0 && user.TeamGroupSN == 0)
            {
                user.TeamGroupSN = TeamGroupSN;
                dbUser.UpdateUserInfo(user);
                result.setMessage(string.Empty);
            }
            else
            {
                if (user.TeamGroupSN == TeamGroupSN && user.SN > 0)
                {
                    result.setErrorMessage("該成員已是本團隊成員之一。");
                }
                else if (user.TeamGroupSN > 0 && user.SN > 0)
                {
                    var tg = dbTgroup.getTeamGroupBySN(user.TeamGroupSN);
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
            var user = dbUser.getUserBySN(SN);
            if (user != null && user.SN > 0)
            {
                user.TeamGroupSN = 0;
                dbUser.UpdateUserInfo(user);
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
