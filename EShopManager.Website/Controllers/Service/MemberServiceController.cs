using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopManager.Core.Utility;
using EShopManager.Core.DB;
using EShopManager.Website.Models;
using CWB.Web;
using CWB.Web.Configuration;
using EShopManager.Core.Constancy;
using EShopManager.Core;
using EShopManager.Core.MVC.BaseController;
using System.IO;
using EShopManager.Core.Cache.Board;

namespace EShopManager.Website.Controllers.Service
{
    public class MemberServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(MemberServiceController));
        private static readonly DbTopicTable dbTopic = new DbTopicTable() { };
        private static readonly DbTopicMemberTable dbTopMem = new DbTopicMemberTable() { };
        private static readonly DbUserTable dbUser = new DbUserTable() { };

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
                        var user = dbUser.getUserBySN(sessionData.trading.sn);
                        TopicPublishType opentype = EnumHelper.GetEnumByName<TopicPublishType>(opento.ToString());
                        if (opentype == TopicPublishType.TeamGroup && user.TeamGroupSN < 1)
                        {
                            result.setErrorMessage("您尚未被加入任一個團體。");
                        }
                        else
                        {
                            bool flag = dbTopic.AddNewTopic(Subject, sessionData.trading.LoginId, EnumHelper.GetEnumByName<TopicPublishType>(opento.ToString()), user.TeamGroupSN);
                            if (!flag)
                            {
                                result.setException(new Exception("開新議題失敗。"), Log);
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
            var topic = dbTopic.getFirstTopicByUsersSN(sessionData.trading.sn);
            if (topic == null || topic.SN == 0)
            {
                bool isJoinSuccess = dbTopMem.AddNewTopicMember(SN, sessionData.trading.sn);
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
            var user = dbUser.getUserBySN(sessionData.trading.sn);
            if (user != null && user.SN > 0)
            {
                if (string.Compare(user.Password, OldPassword) == 0)
                {
                    user.Password = NewPassword;
                    dbUser.UpdateUserInfo(user);
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
        public JsonResult UpdateMyInfo(string Professional, string UserName)
        {
            ResultBase result = new ResultBase();
            DbUserModel user = dbUser.getUserBySN(sessionData.trading.sn);
            user.Professional = Professional;
            user.UserName = UserName;
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
                BoardCache.ChangePersionPicture(sessionData.trading.sn, NewPicPath);
            }

            dbUser.UpdateUserInfo(user);
            result.JsonReturnCode = 1;
            result.Message = "資料已更新。";
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}
