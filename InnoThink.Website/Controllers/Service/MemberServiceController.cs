using CWB.Web.Configuration;
using InnoThink.Core.Cache.Board;
using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System;
using System.IO;
using System.Web.Mvc;
using InnoThink.BLL.User;
using InnoThink.Domain;
using InnoThink.BLL.Topic;
using InnoThink.BLL.TopicMember;

namespace InnoThink.Website.Controllers.Service
{
    public class MemberServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(MemberServiceController));

        private static readonly Topic_Manager dbTopic = new Topic_Manager();

        private static readonly TopicMember_Manager dbTopMem = new TopicMember_Manager() { };
        

        public MemberServiceController()
            : base(Permission.Private)
        {
        }

        [HttpPost]
        public JsonResult NewTopic(string Subject, int opento)
        {
            ResultBase result = new ResultBase() { };
            if (Subject.Length > 100)
            {
                result.setErrorMessage("議題名稱長度超過上限。");
            }
            else
            {
                if (Subject.Length == 0)
                {
                    result.setErrorMessage("議題名稱不得留空");
                }
                else
                {
                    //check is product there
                    bool isExistSubjectName = dbTopic.CheckSubjectIsExist(Subject);
                    if (isExistSubjectName)
                    {
                        result.setErrorMessage("相同議題名稱已存在。");
                    }
                    else
                    {
                        User_Manager um = new User_Manager();
                        var user = um.GetBySN(sessionData.trading.UserSN);
                        TopicPublishType opentype = EnumHelper.GetEnumByName<TopicPublishType>(opento.ToString());
                        if (opentype == TopicPublishType.TeamGroup && user.TeamGroupSN < 1)
                        {
                            result.setErrorMessage("您尚未被加入任一個團體。");
                        }
                        else
                        {
                            var data = new Topic_Info()
                            {
                                Subject = Subject,
                                PublishType = (int)opentype,
                                TeamGroupSN = user.TeamGroupSN
                            };
                            bool flag = dbTopic.Insert(data) > 0;
                            if (!flag)
                            {
                                result.setException(new Exception("開新議題失敗。"), "NewTopic");
                            }
                            else
                            {
                                result.JsonReturnCode = 1;
                            }
                        }
                    }
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult JoinTopic(int SN)
        {
            ResultBase result = new ResultBase();
            //Check is therea re joined topic.
            var dbTopic = new Topic_Manager();
            var Topic = dbTopic.getFirstTopicByUsersSN(sessionData.trading.UserSN);
            if (Topic == null || Topic.TopicSN == 0)
            {
                bool isJoinSuccess = dbTopMem.Insert(new TopicMember_Info()
                {
                    TopicSN = SN,
                    UserSN = sessionData.trading.UserSN
                }) > 0;
                if (isJoinSuccess)
                {
                    result.JsonReturnCode = 1;
                    result.Message = "參加申請已送出。";
                }
                else
                {
                    result.setException("參加申請失敗，請勿重覆參加。", "JoinTopic");
                }
            }
            else
            {
                result.JsonReturnCode = -1;
                result.Message = "每人只能參加一個議題。";
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult ChangePassword(string NewPassword, string OldPassword)
        {
            ResultBase result = new ResultBase();
            User_Manager um = new User_Manager();
            var user = um.GetBySN(sessionData.trading.UserSN);
            if (user != null && user.UserSN > 0)
            {
                if (string.Compare(user.Password, OldPassword) == 0)
                {
                    user.Password = NewPassword;
                    um.Update(user);
                    result.setMessage("變更密碼完成。");
                }
                else
                {
                    result.setErrorMessage("您的舊密碼不正確。");
                }
            }
            else
            {
                result.setErrorMessage("登入資訊遺失，請重新登入。");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateMyInfo(string Professional, string UserName, int TeamGroupSN)
        {
            ResultBase result = new ResultBase();
            User_Manager um = new User_Manager();
            var user = um.GetBySN(sessionData.trading.UserSN);

            user.Professional = Professional;
            user.UserName = UserName;
            user.TeamGroupSN = TeamGroupSN;
            if (!string.IsNullOrEmpty(sessionData.trading._tempFileName))
            {
                //user has upload person icon, need update the value.
                user.Picture = sessionData.trading._tempFileName;
                //Clear template file.
                sessionData.trading._tempFileName = string.Empty;
                string FileSource = string.Format("{0}{1}/{2}", Server.MapPath("~/"), AppConfigManager.SystemSetting.FileUpLoadTempFolder, user.Picture);
                string FileDisc = string.Format("{0}{1}/{2}", Server.MapPath("~/"), AppConfigManager.SystemSetting.FileUpLoadIcon, user.Picture);
                FileInfo f = new FileInfo(FileSource);
                f.MoveTo(FileDisc);
                //Update Cache picture
                string NewPicPath = StringUtility.ConvertPicturePath(user.Picture);
                BoardCache.ChangePersionPicture(sessionData.trading.UserSN, NewPicPath);
            }

            um.Update(user);
            result.JsonReturnCode = 1;
            result.Message = "資料已更新。";
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}