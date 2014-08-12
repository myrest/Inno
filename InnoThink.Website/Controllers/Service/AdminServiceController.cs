using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System.Web.Mvc;
using InnoThink.BLL.User;
using System.Linq;
using InnoThink.Domain;

namespace InnoThink.Website.Controllers.Service
{
    public class AdminServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AdminServiceController));

        private static readonly DbTopicTable dbTopic = new DbTopicTable() { };
        private static readonly DbTopicMemberTable dbTopMem = new DbTopicMemberTable() { };
        
        private static readonly DbTeamGroupTable dbTgroup = new DbTeamGroupTable() { };

        public AdminServiceController()
            : base(Permission.Private)
        {
        }

        [HttpPost]
        public JsonResult AdjustUserPosition(string UserLoginId, int Position)
        {
            //This should be remove, only Admin account can' has permission, user is only user.
            ResultBase result = new ResultBase() { };
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