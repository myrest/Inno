using CWB.Web.Configuration;
using InnoThink.Core;
using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.Model.Topic;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Website.Communication;
using InnoThink.Website.Models;
using InnoThink.Website.Models.Topic;
using Newtonsoft.Json;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnoThink.BLL.User;
using InnoThink.Domain;
using InnoThink.BLL.Topic;
using InnoThink.BLL.TopicMember;
using InnoThink.Domain.InnoThinkMain.Binding;

namespace InnoThink.Website.Controllers.Service
{
    public class TopicServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(TopicServiceController));

        private static readonly Topic_Manager dbTopic = new Topic_Manager();

        private static readonly TopicMember_Manager dbTopMem = new TopicMember_Manager() { };
        
        private static readonly DbBestStep1Table dbBest1 = new DbBestStep1Table() { };
        private static readonly DbBestIdeaTable dbBestIdea = new DbBestIdeaTable() { };
        private static readonly DbBestIdeaMemRankTable dbBestIdeaMemRank = new DbBestIdeaMemRankTable() { };
        private static readonly DbBestIdeaGroupTable dbBestIdeaGrp = new DbBestIdeaGroupTable() { };
        private static readonly DbBestIdeaGroupRankTable dbBestIdeaGrpRank = new DbBestIdeaGroupRankTable() { };
        private static readonly DbBestGAPTable dbBestGAP = new DbBestGAPTable() { };
        private static readonly DbResultsTable dbResult = new DbResultsTable() { };

        public TopicServiceController()
            : base(Permission.Private)
        {
        }

        [HttpPost]
        public JsonResult DeleteTopic(int SN)
        {
            ResultBase result = new ResultBase() { };
            if (SN > 0)
            {
                dbTopic.Delete(SN);
            }
            result.setMessage("資料已刪除。");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateUnit1Description(UpdateUnit1DescriptionUI data)
        {
            ResultBase result = new ResultBase() { };
            TopicMember_Info TopicMember = dbTopMem.getTopicMember(data.TopicSN, sessionData.trading.UserSN);
            TopicMember.LeaderSNVoteTo = data.LeaderVote;
            TopicMember.Description = data.Descript;
            dbTopMem.Update(TopicMember);
            //Get user object.
            User_Manager um = new User_Manager();
            var User = um.GetBySN(sessionData.trading.UserSN);

            //Get all team member vote for leader.
            var TeamMembers = dbTopMem.getALLTopicMember(data.TopicSN);
            var LeaderVotes = TeamMembers.ToDictionary(x => x.UserSN, x => TeamMembers.Where(y => y.LeaderSNVoteTo == x.UserSN).Count());

            //Update date topic inofrmation for leader login id.
            int LeaderSN = LeaderVotes.OrderByDescending(x => x.Value).ThenBy(x => x.Key).First().Key;
            var User_Leader = um.GetBySN(LeaderSN);
            var TopicInfo = dbTopic.GetBySN(data.TopicSN);
            TopicInfo.LeaderLoginId = User_Leader.LoginId;
            dbTopic.Update(TopicInfo);

            //SignalR Update UI
            SignalRMessageUnitModel msg = new SignalRMessageUnitModel()
            {
                MessageType = SignalRMessageType.Unit1,
                data = new MessageUnit()
                {
                    Name = User.UserName,
                    Picture = StringUtility.ConvertPicturePath(User.Picture),
                    Professional = User.Professional,
                    SN = User.UserSN,
                    Description = data.Descript.Replace("\n", "<BR>"),
                    Votes = LeaderVotes,
                    LeaderName = um.GetBySN(LeaderVotes.OrderByDescending(x => x.Value).ThenBy(x => x.Key).First().Key).UserName
                }
            };
            CommServer.Instance.Unit1update(data.TopicSN, msg);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateTopicStep1(UpdateTopicStep1UI Paras)
        {
            ResultBase result = new ResultBase() { };

            #region Process Topic related
            var dbTopic = new Topic_Manager();
            Topic_Info Topic = dbTopic.GetBySN(Paras.TopicSN);
            //Deal with topic information.
            Topic.Subject = Paras.Subject;
            Topic.Target = Paras.Target;
            Topic.TeamName = Paras.TeamName;
            //Deal with topic logo
            if (!string.IsNullOrEmpty(sessionData.trading._tempFileName))
            {
                //user has upload person icon, need update the value.
                Topic.LogoImg = sessionData.trading._tempFileName;
                //Clear template file and temp int.
                sessionData.trading._tempInt = default(int);
                string FileSource = string.Format("{0}{1}/{2}", Server.MapPath("~/"), AppConfigManager.SystemSetting.FileUpLoadTempFolder, Topic.LogoImg);
                string FileDisc = string.Format("{0}{1}/{2}", Server.MapPath("~/"), AppConfigManager.SystemSetting.FileUpLoadTeamLogo, Topic.LogoImg);
                FileInfo f = new FileInfo(FileSource);
                f.MoveTo(FileDisc);
            }
            dbTopic.Update(Topic);

            #endregion Process Topic related

            #region Process Topic Member related.

            var Jobs = JsonConvert.DeserializeObject<List<string>>(Paras.HandleJob_ALL);
            Jobs.ForEach(x =>
            {
                //Get user sn and value in string, spread by ',', first is UserSN, second is Handle job detail.
                var handjobarr = x.Split(new char[] { ',' }, 2);
                var TopicMem = dbTopMem.getTopicMember(Paras.TopicSN, Convert.ToInt32(handjobarr[0]));
                TopicMem.HandleJob = handjobarr[1];
                dbTopMem.Update(TopicMem);
            });
            //dbTopMem.Update

            #endregion Process Topic Member related.

            //need update client's information for step 1.

            var topic = dbTopic.GetBySN(Paras.TopicSN);
            var alluser = dbTopMem.getALLTopicMember(Paras.TopicSN);
            var users = alluser.Select(x => new KeyValuePair<string, string>(x.UserName, x.HandleJob));
            topic.LogoImg = StringUtility.ConvertTeamLogoPath(topic.LogoImg);
            CommServer.Instance.syncStep1(topic, users);

            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoStep1(int TopicSN)
        {
            int GotoStep = 1;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            //Get all team member vote for leader.
            List<TopicMemberUI> TeamMembers;
            result = ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoStep0(int TopicSN)
        {
            int GotoStep = 0;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<TopicMemberUI> TeamMembers;
            result = ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoBest1(int TopicSN)
        {
            int GotoStep = 11;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<TopicMemberUI> TeamMembers;
            result = ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoBest2(int TopicSN)
        {
            int GotoStep = 12;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<TopicMemberUI> TeamMembers;
            result = ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoBest3(int TopicSN)
        {
            int GotoStep = 13;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<TopicMemberUI> TeamMembers;
            result = ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoBest4(int TopicSN)
        {
            int GotoStep = 14;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<TopicMemberUI> TeamMembers;
            result = ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoBest5(int TopicSN)
        {
            int GotoStep = 15;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<TopicMemberUI> TeamMembers;
            result = ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoBest6(int TopicSN)
        {
            int GotoStep = 16;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<TopicMemberUI> TeamMembers;
            result = ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoResult1(int TopicSN)
        {
            int GotoStep = 9901;
            ResultBase result = doGotoResult(TopicSN, GotoStep);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoResult2(int TopicSN)
        {
            int GotoStep = 9902;
            ResultBase result = doGotoResult(TopicSN, GotoStep);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoResult3(int TopicSN)
        {
            int GotoStep = 9903;
            ResultBase result = doGotoResult(TopicSN, GotoStep);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private ResultBase doGotoResult(int TopicSN, int GotoStep)
        {
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<TopicMemberUI> TeamMembers;
            result = ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            result.JsonReturnCode = 1;
            return result;
        }

        [HttpPost]
        public JsonResult CheckTopic(int SN)
        {
            ResultBase result = GetTopicNextStep(SN);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetFirstTopic()
        {
            ResultBase result = new ResultBase() { };
            //Get the first joined topic.
            var dbTopic = new Topic_Manager();
            var Topic = dbTopic.getFirstTopicByUserSN(sessionData.trading.UserSN);
            if (Topic != null && Topic.TopicSN > 0)
            {
                result = GetTopicNextStep(Topic.TopicSN);
            }
            else
            {
                result.Message = "您還沒參加任何一個議題。";
                result.JsonReturnCode = -1;
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        //Should remove "out List<TopicMember_Info> OutTeamMembers" parameter for performance issue.
        public static ResultBase ProcessGotoStep(int TopicSN, int GotoStep, Trading trading, out List<TopicMemberUI> OutTeamMembers)
        {
            ResultBase result = new ResultBase() { };
            //Check the Leader
            //Get all team member vote for leader.
            List<TopicMemberUI> TeamMembers = dbTopMem.getALLTopicMember(TopicSN);
            var LeaderVotes = TeamMembers.ToDictionary(x => x.UserSN, x => TeamMembers.Where(y => y.LeaderSNVoteTo == x.UserSN).Count());
            int LeaderSN = LeaderVotes.OrderByDescending(x => x.Value).ThenBy(x => x.Key).First().Key;
            User_Manager um = new User_Manager();
            var User_Leader = um.GetBySN(LeaderSN);
            var TopicInfo = dbTopic.GetBySN(TopicSN);
            if (LeaderSN == trading.UserSN)
            {
                //set the step for the topic.
                TopicInfo.Step = GotoStep;
                dbTopic.Update(TopicInfo);

                //let all the teammember into next step.
                ResultBase nextstep = GetTopicNextStep(TopicSN);
                if (nextstep.JsonReturnCode > 0)
                {
                    CommServer.Instance.JumpToStep(TopicSN, nextstep.Message);
                    result.JsonReturnCode = 1;
                }
                else
                {
                    result.JsonReturnCode = -1;
                    result.Message = "取得下一步驟失敗。";
                }
            }
            else
            {
                result.JsonReturnCode = -1;
                result.Message = "您目前不是隊長，無法使用該功能。";
            }
            OutTeamMembers = TeamMembers;
            return result;
        }

        private static ResultBase GetTopicNextStep(int SN)
        {
            ResultBase result = new ResultBase();
            var dbTopic = new Topic_Manager();
            var Topic = dbTopic.GetBySN(SN);
            //check topic is exist
            if (Topic.TopicSN > 0)
            {
                //check topic is on going.
                if (Topic.DateClosed == DateTime.MinValue)
                {
                    var TopicMem = dbTopMem.getALLTopicMember(SN);
                    //check topic has team member.
                    if (TopicMem.Count() > 0)
                    {
                        result.JsonReturnCode = 1;
                        //Get current step.
                        switch (Topic.Step)
                        {
                            case 0:
                                result.Message = "/Topic/Step0?TopicSN=" + Topic.TopicSN;
                                break;

                            case 1:
                                result.Message = "/Topic/Step1?TopicSN=" + Topic.TopicSN;
                                break;

                            case 11:
                                result.Message = "/Topic/Best1?TopicSN=" + Topic.TopicSN;
                                break;

                            case 12:
                                result.Message = "/Topic/Best2?TopicSN=" + Topic.TopicSN;
                                break;

                            case 13:
                                result.Message = "/Topic/Best3?TopicSN=" + Topic.TopicSN;
                                break;

                            case 14:
                                result.Message = "/Topic/Best4?TopicSN=" + Topic.TopicSN;
                                break;

                            case 15:
                                result.Message = "/Topic/Best5?TopicSN=" + Topic.TopicSN;
                                break;

                            case 16:
                                result.Message = "/Topic/Best6?TopicSN=" + Topic.TopicSN;
                                break;
                            //情境分析法開始
                            case 31:
                                result.Message = "/Scenario/Scenario1?TopicSN=" + Topic.TopicSN;
                                break;

                            case 32:
                                result.Message = "/Scenario/Scenario2?TopicSN=" + Topic.TopicSN;
                                break;

                            case 33:
                                result.Message = "/Scenario/Scenario3?TopicSN=" + Topic.TopicSN;
                                break;

                            case 34:
                                result.Message = "/Scenario/Scenario4?TopicSN=" + Topic.TopicSN;
                                break;

                            case 35:
                                result.Message = "/Scenario/Scenario5?TopicSN=" + Topic.TopicSN;
                                break;

                            case 36:
                                result.Message = "/Scenario/Scenario6?TopicSN=" + Topic.TopicSN;
                                break;

                            case 37:
                                result.Message = "/Scenario/Scenario7?TopicSN=" + Topic.TopicSN;
                                break;
                            //情境分析法結束
                            case 9901:
                                result.Message = "/Topic/Result1?TopicSN=" + Topic.TopicSN;
                                break;

                            case 9902:
                                result.Message = "/Topic/Result2?TopicSN=" + Topic.TopicSN;
                                break;

                            case 9903:
                                result.Message = "/Topic/Result3?TopicSN=" + Topic.TopicSN;
                                break;

                            default:
                                result.setException("該功能處於施工中。", "CheckTopic");
                                break;
                        }
                    }
                    else
                    {
                        result.setErrorMessage("該議題還沒有人加入。");
                    }
                }
                else
                {
                    //result.setErrorMessage("該議題已結束。");
                    //Redirect the the first step.
                    result.setMessage("/Topic/Step0?TopicSN=" + Topic.TopicSN);
                }
            }
            else
            {
                result.setErrorMessage("該議題不存在。");
            }
            return result;
        }

        [HttpPost]
        public JsonResult Result1(string Column1, string Column2, string Column3, string Column4, int TopicSN)
        {
            ResultBase result = doResultSave(Column1, Column2, Column3, Column4, TopicSN, ResultType.DRAFT);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult Result2(string Column1, string Column2, string Column3, string Column4, int TopicSN)
        {
            ResultBase result = doResultSave(Column1, Column2, Column3, Column4, TopicSN, ResultType.DASHBOARD);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult Result3(string Column1, string Column2, string Column3, string Column4, int TopicSN)
        {
            ResultBase result = doResultSave(Column1, Column2, Column3, Column4, TopicSN, ResultType.PRESENTATION);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private ResultBase doResultSave(string Column1, string Column2, string Column3, string Column4, int TopicSN, ResultType Result)
        {
            ResultBase rtn = new ResultBase() { };
            if (string.IsNullOrEmpty(Column1) || string.IsNullOrEmpty(Column2))
            {
                List<string> errmsg = new List<string>() { };
                if (string.IsNullOrEmpty(Column1))
                {
                    errmsg.Add("主旨為必填欄位");
                }
                if (string.IsNullOrEmpty(Column2))
                {
                    errmsg.Add("說明為必填欄位");
                }
                rtn.setErrorMessage(string.Join(Environment.NewLine, errmsg.ToArray()));
            }
            else
            {
                DbResultsModel model = new DbResultsModel()
                {
                    Column1 = Column1,
                    Column2 = Column2,
                    Column3 = Column3,
                    Column4 = Column4,
                    Result = Result,
                    ServerFileName = sessionData.trading._tempFileName,
                    UserFileName = sessionData.trading._OrignFileName,
                    TopicSN = TopicSN,
                    UserSN = sessionData.trading.UserSN,
                    IsImage = sessionData.trading._isImage ? 1 : 0
                };
                int NewSN = dbResult.Add(model);
                sessionData.ClearTempValue();
                model.SN = NewSN;
                //publish to each client for Sync UI display.
                model.ServerFileName = StringUtility.ConvertResultsPath(model.ServerFileName);
                CommServer.Instance.syncUIResult(model, Result);
                rtn.setMessage("Done");
            }
            return rtn;
        }

        [HttpPost]
        public JsonResult NewBest1(string Category, string Description, string Related, int TopicSN)
        {
            ResultBase result = new ResultBase() { };
            DbBestStep1Model model = new DbBestStep1Model()
            {
                Category = Category,
                Description = Description,
                Related = Related,
                TopicSN = TopicSN,
                Image = sessionData.trading._tempFileName,
                UserSN = sessionData.trading.UserSN
            };
            int NewSN = dbBest1.Add(model);
            sessionData.ClearTempValue();
            model.SN = NewSN;
            //publish to each client for Sync UI display.
            model.Image = string.Format("<p><img src=\"{0}\" /></p>", StringUtility.ConvertBestPath(model.Image));
            CommServer.Instance.syncUIBest1(model);

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateBestGAP(string MyGAP, string Description, string SNs, int BestGAPSN)
        {
            ResultBase result = new ResultBase() { };
            var AllBestIdeaGroupSN = JsonConvert.DeserializeObject<List<string>>(SNs);
            List<DbBestGAPMemberModel> SubItem = new List<DbBestGAPMemberModel>() { };
            AllBestIdeaGroupSN.ForEach(x =>
            {
                SubItem.Add(new DbBestGAPMemberModel() { BestIdeaGroupSN = Convert.ToInt32(x) });
            });

            //Get existing data
            var Model = dbBestGAP.GetByBestGAPSN(BestGAPSN);

            //set data for update
            Model.Description = Description;
            Model.MyGAP = MyGAP;
            Model.IdeaDetails = SubItem;
            //if user update file, need to copy file from temp folder to the upload folder.
            if (!string.IsNullOrEmpty(sessionData.trading._tempFileName))
            {
                if (string.Compare("DELETE", sessionData.trading._tempFileName, true) == 0)
                {
                    string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadBest, Model.Document);
                    FileInfo f = new FileInfo(FileDisc);
                    f.Delete();
                    Model.Document = string.Empty;
                }
                else
                {
                    string FileSource = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadTempFolder, sessionData.trading._tempFileName);
                    if (string.IsNullOrEmpty(Model.Document))
                    {
                        Model.Document = "Best6" + Model.SN + Path.GetExtension(FileSource);
                    }
                    string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadBestGAP, Model.Document);
                    FileInfo f = new FileInfo(FileDisc);
                    f.Delete();
                    f = new FileInfo(FileSource);
                    f.MoveTo(FileDisc);
                }
            }

            dbBestGAP.InsertOrReplace(Model);
            sessionData.ClearTempValue();
            //get from DB.
            Model = dbBestGAP.GetByBestGAPSN(Model.SN);
            if (!string.IsNullOrEmpty(Model.Document))
            {
                Model.Document = StringUtility.ConvertGAPPath(Model.Document);
            }
            CommServer.Instance.syncUIBestIGAP(Model);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateBest1(string Category, string Description, string Related, int SN)
        {
            ResultBase result = new ResultBase() { };
            var model = dbBest1.GetBySN(SN);
            model.Category = Category;
            model.Description = Description;
            model.Related = Related;
            //if user update file, need to copy file from temp folder to the upload folder.
            if (!string.IsNullOrEmpty(sessionData.trading._tempFileName))
            {
                if (string.Compare("DELETE", sessionData.trading._tempFileName, true) == 0)
                {
                    string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadBest, model.Image);
                    FileInfo f = new FileInfo(FileDisc);
                    f.Delete();
                    model.Image = string.Empty;
                }
                else
                {
                    string FileSource = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadTempFolder, sessionData.trading._tempFileName);
                    if (string.IsNullOrEmpty(model.Image))
                    {
                        model.Image = "Best1" + model.SN + Path.GetExtension(FileSource);
                    }
                    string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadBest, model.Image);
                    FileInfo f = new FileInfo(FileDisc);
                    f.Delete();
                    f = new FileInfo(FileSource);
                    f.MoveTo(FileDisc);
                }
            }
            dbBest1.Update(model);
            sessionData.ClearTempValue();
            //publish to each client for Sync UI display.
            model.Image = string.Format("<p><img src=\"{0}\" /></p>", StringUtility.ConvertBestPath(model.Image));
            CommServer.Instance.syncUIBest1(model);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateResult(string Column1, string Column2, string Column3, string Column4, int SN)
        {
            ResultBase result = new ResultBase() { };
            var model = dbResult.GetBySN(SN);
            model.Column1 = Column1;
            model.Column2 = Column2;
            model.Column3 = Column3;
            model.Column4 = Column4;
            //if user update file, need to copy file from temp folder to the upload folder.
            if (!string.IsNullOrEmpty(sessionData.trading._tempFileName))
            {
                if (string.Compare("DELETE", sessionData.trading._tempFileName, true) == 0)
                {
                    string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadBest, model.ServerFileName);
                    FileInfo f = new FileInfo(FileDisc);
                    f.Delete();
                    model.ServerFileName = string.Empty;
                    model.UserFileName = string.Empty;
                    model.IsImage = 0;
                }
                else
                {
                    //Copy file
                    string FileSource = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadTempFolder, sessionData.trading._tempFileName);
                    string NewName = string.Format("Result{0}_{1}", SN, sessionData.trading._tempFileName);//Path.GetExtension(Model.UserFileName);
                    string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadResult, NewName);
                    FileInfo f = new FileInfo(FileDisc);
                    f.Delete();
                    f = new FileInfo(FileSource);
                    f.MoveTo(FileDisc);
                    model.UserFileName = sessionData.trading._OrignFileName;
                    model.ServerFileName = NewName;
                    model.IsImage = sessionData.trading._isImage ? 1 : 0;
                }
            }
            bool updateFlag = dbResult.Update(model);
            sessionData.ClearTempValue();
            //publish to each client for Sync UI display.
            model.ServerFileName = StringUtility.ConvertResultsPath(model.ServerFileName);

            if (updateFlag)
            {
                CommServer.Instance.syncUIResult(model, model.Result);
                result.setMessage("Done");
            }
            else
            {
                result.setErrorMessage("Update got server error, please check with web admin.");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateBestIdea(string Description, string Idea, int SN)
        {
            ResultBase result = new ResultBase() { };
            DbBestIdeaModel model = dbBestIdea.GetBySN(SN);
            model.Description = Description;
            model.Idea = Idea;
            dbBestIdea.Update(model);
            sessionData.ClearTempValue();
            CommServer.Instance.syncUIBestIdea(model);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult NewBestIdea(int TopicSN, string Type, string Idea, string Description)
        {
            ResultBase result = new ResultBase() { };
            string BType = Type.Substring(Type.Length - 1).ToUpper();
            DbBestIdeaModel model = new DbBestIdeaModel()
            {
                Description = Description,
                Idea = Idea,
                TopicSN = TopicSN,
                Type = EnumHelper.GetEnumByName<BestType>(BType),
                UserSN = sessionData.trading.UserSN
            };
            int NewSN = dbBestIdea.Add(model);
            sessionData.ClearTempValue();
            model.SN = NewSN;
            CommServer.Instance.syncUIBestIdea(model);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetBest1Info(int SN)
        {
            Best1ViewModel result = new Best1ViewModel() { };
            sessionData.ClearTempValue();
            DbBestStep1Model model = dbBest1.GetBySN(SN);
            //publish to each client for Sync UI display.
            model.Image = string.Format("<p><img src=\"{0}\" /></p>", StringUtility.ConvertBestPath(model.Image));
            result.Listing = new List<DbBestStep1Model>() { };
            result.Listing.Add(model);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetResultInfo(int SN)
        {
            ResultViewModel result = new ResultViewModel() { };
            sessionData.ClearTempValue();
            var model = dbResult.GetBySN(SN);
            //publish to each client for Sync UI display.
            model.ServerFileName = StringUtility.ConvertResultsPath(model.ServerFileName);
            result.Listing = new List<DbResultsModel>() { };
            result.Listing.Add(model);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateResultRank(int SN, int Rank, string Comment)
        {
            ResultBase result = new ResultBase() { };
            try
            {
                var syncObj = dbResult.InsertOrReplaceRank(sessionData.trading.UserSN, SN, Rank, Comment);
                result.setMessage("Done");
                CommServer.Instance.syncUIResultScore(syncObj);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
                result.setErrorMessage("評分失敗。");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetResultRankComment(int SN)
        {
            ResultRankCommentListModel result = new ResultRankCommentListModel() { };
            try
            {
                var data = dbResult.GetAllCommentByResultSN(SN);
                data.ForEach(x => x.Image = StringUtility.ConvertPicturePath(x.Image));
                result.Listing = data;
                result.setMessage("Done");
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
                result.setErrorMessage("取得評分失敗。");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateBestIdeaRank(string Ranks)
        {
            ResultBase result = new ResultBase() { };
            var AllRank = JsonConvert.DeserializeObject<List<string>>(Ranks);
            AllRank.ForEach(x =>
            {
                //Get user sn and value in string, spread by ',', first is UserSN, second is Handle job detail.
                var RankArr = x.Split(new char[] { ',' }, 2);
                DbBestIdeaMemRankModel model = new DbBestIdeaMemRankModel()
                {
                    BestIdeaSN = Convert.ToInt32(RankArr[0]),
                    Rank = Convert.ToInt32(RankArr[1]),
                    UserSN = sessionData.trading.UserSN
                };
                dbBestIdeaMemRank.InsertOrReplace(model);
            });

            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateBestIdeaGroupRank(string Ranks)
        {
            ResultBase result = new ResultBase() { };
            var AllRank = JsonConvert.DeserializeObject<List<string>>(Ranks);
            AllRank.ForEach(x =>
            {
                //Get user sn and value in string, spread by ',', first is UserSN, second is Handle job detail.
                var RankArr = x.Split(new char[] { ',' }, 2);
                DbBestIdeaGroupRankModel model = new DbBestIdeaGroupRankModel()
                {
                    BestIdeaGroupSN = Convert.ToInt32(RankArr[0]),
                    Rank = Convert.ToInt32(RankArr[1]),
                    UserSN = sessionData.trading.UserSN
                };
                dbBestIdeaGrpRank.InsertOrReplace(model);
            });

            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult LeaveTopic(int TopicSN)
        {
            ResultBase result = new ResultBase() { };
            var model = dbTopic.GetBySN(TopicSN);
            if (model.DateClosed == DateTime.MinValue)
            {
                var data = dbTopMem.GetByParameter(new TopicMember_Filter()
                {
                    UserSN = sessionData.trading.UserSN,
                    TopicSN = TopicSN
                }).FirstOrDefault();
                if (data != null)
                {
                    dbTopMem.Delete(data.TopicMemberSN);
                }
                result.setMessage("您已退出該議題討論。");
            }
            else
            {
                result.setErrorMessage("該議題已關閉。");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult NewBestIdeaGroup(int TopicSN, string Type, string GroupName, string BestIdeaSNs)
        {
            ResultBase result = new ResultBase() { };
            var AllBestIdeaSN = JsonConvert.DeserializeObject<List<string>>(BestIdeaSNs);
            List<DbBestIdeaGroupMember> inBestIdeaSNs = new List<DbBestIdeaGroupMember>() { };
            AllBestIdeaSN.ForEach(x =>
                {
                    inBestIdeaSNs.Add(new DbBestIdeaGroupMember() { BestIdeaSN = Convert.ToInt32(x) });
                });
            string BType = Type.Substring(Type.Length - 1).ToUpper();
            DbBestIdeaGroup model = new DbBestIdeaGroup()
            {
                TopicSN = TopicSN,
                Type = EnumHelper.GetEnumByName<BestType>(BType),
                GroupName = GroupName,
                IdeaDetails = inBestIdeaSNs
            };
            int NewSN = dbBestIdeaGrp.Add(model);
            sessionData.ClearTempValue();
            //get from DB.
            model = dbBestIdeaGrp.GetALLByBestIdeaGroupSN(NewSN);
            CommServer.Instance.syncUIBestIdeaGroup(model);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult NewBestGAP(int TopicSN, string MyGAP, string Description, string SNs)
        {
            ResultBase result = new ResultBase() { };
            var AllBestIdeaGroupSN = JsonConvert.DeserializeObject<List<string>>(SNs);
            List<DbBestGAPMemberModel> SubItem = new List<DbBestGAPMemberModel>() { };
            AllBestIdeaGroupSN.ForEach(x =>
            {
                SubItem.Add(new DbBestGAPMemberModel() { BestIdeaGroupSN = Convert.ToInt32(x) });
            });

            DbBestGAPModel model = new DbBestGAPModel()
            {
                TopicSN = TopicSN,
                Description = Description,
                Document = sessionData.trading._tempFileName,
                MyGAP = MyGAP,
                UserSN = sessionData.trading.UserSN,
                IdeaDetails = SubItem
            };
            int NewSN = dbBestGAP.Add(model);
            sessionData.ClearTempValue();
            //get from DB.
            model = dbBestGAP.GetByBestGAPSN(NewSN);
            if (!string.IsNullOrEmpty(model.Document))
            {
                model.Document = StringUtility.ConvertGAPPath(model.Document);
            }
            CommServer.Instance.syncUIBestIGAP(model);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateBestIdeaGroup(int BestIdeaGroupSN, string GroupName, string BestIdeaSNs)
        {
            ResultBase result = new ResultBase() { };
            var AllBestIdeaSN = JsonConvert.DeserializeObject<List<string>>(BestIdeaSNs);
            List<DbBestIdeaGroupMember> inBestIdeaSNs = new List<DbBestIdeaGroupMember>() { };
            AllBestIdeaSN.ForEach(x =>
            {
                inBestIdeaSNs.Add(new DbBestIdeaGroupMember() { BestIdeaSN = Convert.ToInt32(x) });
            });
            //get from DB.
            DbBestIdeaGroup model = dbBestIdeaGrp.GetALLByBestIdeaGroupSN(BestIdeaGroupSN);

            //Set new value
            model.GroupName = GroupName;
            model.IdeaDetails = inBestIdeaSNs;
            dbBestIdeaGrp.InsertOrReplace(model);

            //get from DB again for get idea.
            model = dbBestIdeaGrp.GetALLByBestIdeaGroupSN(BestIdeaGroupSN);
            CommServer.Instance.syncUIBestIdeaGroup(model);
            result.JsonReturnCode = 1;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult BestEnd(int TopicSN)
        {
            ResultBase result = new ResultBase() { };
            result.setMessage("接下來請繼續等待情境分析法。");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult CloseTopic(int TopicSN)
        {
            ResultBase result = new ResultBase() { };
            bool flag = dbTopic.CloseTopic(TopicSN, sessionData.trading.LoginId);
            if (flag)
            {
                result.setMessage("關閉議題完成。");
            }
            else
            {
                result.setErrorMessage("關閉議題失敗，只有隊長可以關閉議題。");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}