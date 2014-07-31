using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopManager.Core.MVC.BaseController;
using EShopManager.Core.Utility;
using EShopManager.Core.DB;
using EShopManager.Website.Models;
using EShopManager.Core.Constancy;
using EShopManager.Website.Communication;
using CWB.Web.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace EShopManager.Website.Controllers.Service
{
    public class ScenarioServiceController : BaseController
    {
        private static readonly SysLog Log = SysLog.GetLogger(typeof(ScenarioServiceController));
        private static readonly DbTopicTable dbTopic = new DbTopicTable() { };
        private static readonly DbResultsTable dbResult = new DbResultsTable() { };
        private static readonly DbScenarioTable dbScenario = new DbScenarioTable() { };

        //
        // GET: /ScenarioService/

        public ScenarioServiceController()
            : base(Permission.Private)
        {
        }

        private ResultBase doValidation(string Column1, string Column2, string Column3, string Column4, int TopicSN, ResultType Result)
        {
            ResultBase rtn = new ResultBase() { };
            //Set to default is pass the validation.
            rtn.JsonReturnCode = 1;
            switch (Result)
            {
                case ResultType.SCENARIO_3:
                case ResultType.SCENARIO_7:
                    #region SCENARIO_3 only using Column2 for 事件描述
                    if (string.IsNullOrEmpty(Column2))
                    {
                        List<string> errmsg = new List<string>() { };
                        if (string.IsNullOrEmpty(Column2))
                        {
                            errmsg.Add("事件描述為必填欄位");
                        }
                        rtn.setErrorMessage(string.Join(Environment.NewLine, errmsg.ToArray()));
                    }
                    #endregion
                    break;
                default:
                    #region Default using Column1, Column2 for "類別", "說明"
                    if (string.IsNullOrEmpty(Column1) || string.IsNullOrEmpty(Column2))
                    {
                        List<string> errmsg = new List<string>() { };
                        if (string.IsNullOrEmpty(Column1))
                        {
                            errmsg.Add("類別為必填欄位");
                        }
                        if (string.IsNullOrEmpty(Column2))
                        {
                            errmsg.Add("說明為必填欄位");
                        }
                        rtn.setErrorMessage(string.Join(Environment.NewLine, errmsg.ToArray()));
                    }
                    #endregion
                    break;
            }
            return rtn;
        }

        private ResultBase doResultSave(string Column1, string Column2, string Column3, string Column4, int TopicSN, ResultType Result, int UserSN)
        {
            if (UserSN == 0)
            {
                UserSN = sessionData.trading.sn;
            }
            ResultBase rtn = doValidation(Column1, Column2, Column3, Column4, TopicSN, Result);
            if (rtn.JsonReturnCode > 0)
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
                    UserSN = UserSN,
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
        public JsonResult Scenario1(string Column1, string Column2, string Column3, string Column4, int TopicSN)
        {
            ResultBase result = doResultSave(Column1, Column2, Column3, Column4, TopicSN, ResultType.SCENARIO_1, sessionData.trading.sn);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult Scenario3(string Column1, string Column2, string Column3, string Column4, int TopicSN)
        {
            ResultBase result = doResultSave(Column1, Column2, Column3, Column4, TopicSN, ResultType.SCENARIO_3, sessionData.trading.sn);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult Scenario7(string Column1, string Column2, string Column3, string Column4, int TopicSN, int UserSN)
        {
            ResultBase result = doResultSave(Column1, Column2, Column3, Column4, TopicSN, ResultType.SCENARIO_7, UserSN);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetALLScenarioByTopicSN(int TopicSN)
        {
            ScenarioCharViewModel result = new ScenarioCharViewModel(sessionData.trading.sn) { };
            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.FirstTime);
            result.Listing = list;
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public class Scenario2SaveObj
        {
            public int AgeRang { get; set; }
            public int Edu { get; set; }
            public int Gender { get; set; }
            public int Salary { get; set; }
            public int TopicSN { get; set; }

            public string Career { get; set; }
            public string CareerOther { get; set; }
            public string Personality { get; set; }
            public string PersonalityOther { get; set; }
            public string Subject { get; set; }
            public string NickName { get; set; }
        }

        public JsonResult Scenario2Save(Scenario2SaveObj obj)
        {
            ResultBase result = new ResultBase() { };
            try
            {
                DbScenarioCharModel model = new DbScenarioCharModel()
                {
                    AgeRang = (AgeRangType)obj.AgeRang,
                    Career = (string.IsNullOrEmpty(obj.Career) ? obj.CareerOther : obj.Career),
                    Edu = (EduType)obj.Edu,
                    Gender = (GenderType)obj.Gender,
                    UserSN = sessionData.trading.sn,
                    SN = 0,
                    TopicSN = obj.TopicSN,
                    NickName = obj.NickName,
                    Personality = (string.IsNullOrEmpty(obj.Personality) ? obj.PersonalityOther : obj.Personality),
                    Salary = (SalaryType)obj.Salary,
                    Subject = obj.Subject,
                    Type = ScenarioType.FirstTime
                };

                if (!string.IsNullOrEmpty(model.Subject) && !string.IsNullOrEmpty(model.NickName))
                {
                    //Get existing SN
                    var ScenarioObjList = dbScenario.GetAllByTopicSN(model.TopicSN, ScenarioType.FirstTime);
                    DbScenarioCharModel oldobj = new DbScenarioCharModel() { };
                    if (ScenarioObjList != null && ScenarioObjList.Count() > 0 && ScenarioObjList.Where(x => x.UserSN == model.UserSN).Count() > 0)
                    {
                        oldobj = ScenarioObjList.Where(x => x.UserSN == model.UserSN).FirstOrDefault();
                        model.SN = oldobj.SN;
                        //if user update file, need to copy file from temp folder to the upload folder.
                        if (!string.IsNullOrEmpty(sessionData.trading._tempFileName))
                        {
                            string UploadFolder = AppConfigManager.SystemSetting.FileUpLoadScenario;
                            const string UploadPrefixFileName = "Scenario";
                            if (string.Compare("DELETE", sessionData.trading._tempFileName, true) == 0)
                            {
                                string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, UploadFolder, oldobj.ServerFileName);
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
                                string NewName = string.Format("{0}{1}_{2}{3}", UploadPrefixFileName, model.TopicSN, model.SN, Path.GetExtension(sessionData.trading._OrignFileName));//Path.GetExtension(Model.UserFileName);
                                string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, UploadFolder, NewName);
                                FileInfo f = new FileInfo(FileDisc);
                                f.Delete();
                                f = new FileInfo(FileSource);
                                f.MoveTo(FileDisc);
                                model.UserFileName = sessionData.trading._OrignFileName;
                                model.ServerFileName = NewName;
                                model.IsImage = sessionData.trading._isImage ? 1 : 0;
                            }
                        }
                        else
                        {
                            //if the template file is empty, need sync with old object.
                            model.ServerFileName = oldobj.ServerFileName;
                            model.UserFileName = oldobj.UserFileName;
                            model.IsImage = oldobj.IsImage;
                        }
                        dbScenario.Update(model);
                    }
                    else
                    {
                        model.ServerFileName = sessionData.trading._tempFileName;
                        model.UserFileName = sessionData.trading._OrignFileName;
                        model.IsImage = sessionData.trading._isImage ? 1 : 0;
                        dbScenario.Add(model);
                    }
                    result.setMessage("Done");
                    model.ServerFileName = StringUtility.ConvertScenarioPath(model.ServerFileName);
                    sessionData.ClearTempValue();
                    CommServer.Instance.syncUIScenario2(model);
                }
                else
                {
                    result.setErrorMessage("暱稱及議題為必填欄位。");
                }
            }
            catch (Exception ex)
            {
                result.setException(ex, "Scenario2Save");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult Scenario6Save(Scenario2SaveObj obj)
        {
            ResultBase result = new ResultBase() { };
            try
            {
                DbScenarioCharModel model = new DbScenarioCharModel()
                {
                    AgeRang = (AgeRangType)obj.AgeRang,
                    Career = (string.IsNullOrEmpty(obj.Career) ? obj.CareerOther : obj.Career),
                    Edu = (EduType)obj.Edu,
                    Gender = (GenderType)obj.Gender,
                    UserSN = sessionData.trading.sn,
                    SN = 0,
                    TopicSN = obj.TopicSN,
                    NickName = obj.NickName,
                    Personality = (string.IsNullOrEmpty(obj.Personality) ? obj.PersonalityOther : obj.Personality),
                    Salary = (SalaryType)obj.Salary,
                    Subject = obj.Subject,
                    Type = ScenarioType.SecondTime
                };
                //Get existing SN
                var ScenarioObjList = dbScenario.GetAllByTopicSN(model.TopicSN, ScenarioType.SecondTime);
                DbScenarioCharModel oldobj = new DbScenarioCharModel() { };
                if (ScenarioObjList != null && ScenarioObjList.Count() > 0 && ScenarioObjList.Where(x => x.UserSN == model.UserSN).Count() > 0)
                {
                    oldobj = ScenarioObjList.Where(x => x.UserSN == model.UserSN).FirstOrDefault();
                    model.SN = oldobj.SN;
                    //if user update file, need to copy file from temp folder to the upload folder.
                    if (!string.IsNullOrEmpty(sessionData.trading._tempFileName))
                    {
                        string UploadFolder = AppConfigManager.SystemSetting.FileUpLoadScenario;
                        const string UploadPrefixFileName = "Scenario";
                        if (string.Compare("DELETE", sessionData.trading._tempFileName, true) == 0)
                        {
                            string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, UploadFolder, oldobj.ServerFileName);
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
                            string NewName = string.Format("{0}{1}_{2}{3}", UploadPrefixFileName, model.TopicSN, model.SN, Path.GetExtension(sessionData.trading._OrignFileName));//Path.GetExtension(Model.UserFileName);
                            string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, UploadFolder, NewName);
                            FileInfo f = new FileInfo(FileDisc);
                            f.Delete();
                            f = new FileInfo(FileSource);
                            f.MoveTo(FileDisc);
                            model.UserFileName = sessionData.trading._OrignFileName;
                            model.ServerFileName = NewName;
                            model.IsImage = sessionData.trading._isImage ? 1 : 0;
                        }
                    }
                    else
                    {
                        //if the template file is empty, need sync with old object.
                        model.ServerFileName = oldobj.ServerFileName;
                        model.UserFileName = oldobj.UserFileName;
                        model.IsImage = oldobj.IsImage;
                    }
                    dbScenario.Update(model);
                }
                else
                {
                    model.ServerFileName = sessionData.trading._tempFileName;
                    model.UserFileName = sessionData.trading._OrignFileName;
                    model.IsImage = sessionData.trading._isImage ? 1 : 0;
                    dbScenario.Add(model);
                }
                result.setMessage("Done");
                model.ServerFileName = StringUtility.ConvertScenarioPath(model.ServerFileName);
                sessionData.ClearTempValue();
                CommServer.Instance.syncUIScenario2(model);
            }
            catch (Exception ex)
            {
                result.setException(ex, "Scenario2Save");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetAllItemList2(int TopicSN)
        {
            ScenarioCharViewModel result = new ScenarioCharViewModel(sessionData.trading.sn) { };
            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.FirstTime);
            if (list != null)
            {
                //Change image path.
                list.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertScenarioPath(x.ServerFileName);
                });
            }
            result.Listing = list;
            result.setMessage("Done");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetAllItemList6(int TopicSN)
        {
            ScenarioCharViewModel result = new ScenarioCharViewModel(sessionData.trading.sn) { };
            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.SecondTime);
            if (list != null)
            {
                //Change image path.
                list.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertScenarioPath(x.ServerFileName);
                });
            }
            result.Listing = list;
            result.setMessage("Done");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetAllItemList3(int TopicSN, int UserSN)
        {
            if (UserSN == 0)
            {
                UserSN = sessionData.trading.sn;
            }

            ScenarioCharResultViewModel result = new ScenarioCharResultViewModel(UserSN) { };
            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.FirstTime);
            if (list != null)
            {
                //Change image path.
                list.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertScenarioPath(x.ServerFileName);
                });
            }
            result.Listing = list;

            //Get all result
            var Scenario3Result = dbResult.GetDataByTopicSN_UserSN(TopicSN, ResultType.SCENARIO_3, UserSN);
            if (Scenario3Result != null)
            {
                //Change image path. due to this is using RESUST module, so need change file path to result path.
                Scenario3Result.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertResultsPath(x.ServerFileName);
                    //for ui display need change crlf to <Br>
                    x.Column2 = x.Column2.Replace(Environment.NewLine, "<br>").Replace("\n", "<br>").Replace("\r", "<br>");
                });
            }
            result.Descriptions = Scenario3Result;

            result.setMessage("Done");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetAllItemList4(int TopicSN, int UserSN)
        {
            if (UserSN == 0)
            {
                UserSN = sessionData.trading.sn;
            }
            ScenarioCharResultViewModel result = new ScenarioCharResultViewModel(UserSN) { };
            #region Char information and result.
            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.FirstTime);
            if (list != null)
            {
                //Change image path.
                list.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertScenarioPath(x.ServerFileName);
                });
            }
            result.Listing = list;

            //Get all result
            var Scenario3Result = dbResult.GetDataByTopicSN_UserSN(TopicSN, ResultType.SCENARIO_3, UserSN);
            if (Scenario3Result != null)
            {
                //Change image path. due to this is using RESUST module, so need change file path to result path.
                Scenario3Result.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertResultsPath(x.ServerFileName);
                    //for ui display need change crlf to <Br>
                    x.Column2 = x.Column2.Replace(Environment.NewLine, "<br>").Replace("\n", "<br>").Replace("\r", "<br>");
                });
            }
            result.Descriptions = Scenario3Result;
            #endregion

            result.ValuePotion = dbScenario.GetAllVPByScenarioCharSN(result.Data.SN);

            result.setMessage("Done");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult GetAllItemList7(int TopicSN, int UserSN)
        {
            if (UserSN == 0)
            {
                UserSN = sessionData.trading.sn;
            }

            ScenarioCharResultViewModel result = new ScenarioCharResultViewModel(UserSN) { };
            var list = dbScenario.GetAllByTopicSN(TopicSN, ScenarioType.SecondTime);
            if (list != null)
            {
                //Change image path.
                list.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertScenarioPath(x.ServerFileName);
                });
            }
            result.Listing = list;

            //Get all result
            var Scenario7Result = dbResult.GetDataByTopicSN_UserSN(TopicSN, ResultType.SCENARIO_7, UserSN);
            if (Scenario7Result != null)
            {
                //Change image path. due to this is using RESUST module, so need change file path to result path.
                Scenario7Result.ForEach(x =>
                {
                    x.ServerFileName = StringUtility.ConvertResultsPath(x.ServerFileName);
                    //for ui display need change crlf to <Br>
                    x.Column2 = x.Column2.Replace(Environment.NewLine, "<br>").Replace("\n", "<br>").Replace("\r", "<br>");
                });
            }
            result.Descriptions = Scenario7Result;

            result.setMessage("Done");
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult Scenario4Update(int TopicSN, int ScenarioCharSN, int ScenarioCharVpSN, string Description)
        {
            DbScenarioCharValueModel model = new DbScenarioCharValueModel() { };
            var vps = dbScenario.GetAllVPByScenarioCharSN(ScenarioCharSN);
            ResultBase result = new ResultBase() { };
            //Check has Data for update.
            if (vps == null || vps.Count() == 0)
            {
                //data not exist.
                result.setErrorMessage("該筆資料不存在。");
            }
            else
            {
                //has data.
                var vp = vps.Where(x => x.SN == ScenarioCharVpSN).FirstOrDefault();
                if (vp == null)
                {
                    result.setErrorMessage("該筆資料不存在。");
                }
                else
                {
                    if (ScenarioCharSN == 0 || ScenarioCharVpSN == 0 || string.IsNullOrEmpty(Description))
                    {
                        if (ScenarioCharSN == 0 || ScenarioCharVpSN == 0)
                        {
                            result.setErrorMessage("ScenarioCharSN or ScenarioCharVpSN is empty.");
                        }
                        else
                        {
                            result.setErrorMessage("有價值點內容不得為空白。");
                        }
                    }
                    else
                    {
                        try
                        {
                            model = new DbScenarioCharValueModel()
                            {
                                Description = Description,
                                UserSN = sessionData.trading.sn,
                                ScenarioCharSN = ScenarioCharSN,
                                SN = ScenarioCharVpSN
                            };
                            dbScenario.UpdateValue(model);
                            CommServer.Instance.syncUIScenario4(TopicSN, model);
                            result.setMessage("Done");
                        }
                        catch (Exception ex)
                        {
                            result.setException(ex, "Scenario4Update");
                        }
                    }
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult Scenario4Save(int TopicSN, int ScenarioSN, string Description)
        {
            DbScenarioCharValueModel model = new DbScenarioCharValueModel() { };
            ResultBase result = new ResultBase() { };
            if (TopicSN == 0 || string.IsNullOrEmpty(Description))
            {
                if (ScenarioSN == 0)
                {
                    result.setErrorMessage("ScenarioSN is empty.");
                }
                else
                {
                    result.setErrorMessage("有價值點內容不得為空白。");
                }
            }
            else
            {
                try
                {
                    model = new DbScenarioCharValueModel()
                    {
                        Description = Description,
                        UserSN = sessionData.trading.sn,
                        ScenarioCharSN = ScenarioSN
                    };
                    model.SN = dbScenario.AddValue(model);
                    CommServer.Instance.syncUIScenario4(TopicSN, model);
                    result.setMessage("Done");
                }
                catch (Exception ex)
                {
                    result.setException(ex, "Scenario4Save");
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult Scenario5Save(string Ranks)
        {
            ResultBase result = new ResultBase() { };
            try
            {
                var AllRank = JsonConvert.DeserializeObject<List<string>>(Ranks);
                AllRank.ForEach(x =>
                {
                    //Get user sn and value in string, spread by ',', first is UserSN, second is Handle job detail.
                    var RankArr = x.Split(new char[] { ',' }, 2);
                    DbScenarioCharValueRankModel model = new DbScenarioCharValueRankModel()
                    {
                        Rank = Convert.ToInt32(RankArr[1]),
                        ScenarioCharValueSN = Convert.ToInt32(RankArr[0]),
                        UserSN = sessionData.trading.sn
                    };
                    dbScenario.InsertOrReplaceScenarioCharValueRank(model);
                });
                result.setMessage("Done");
            }
            catch (Exception ex)
            {
                result.setException(ex, "Scenario5Save");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult Scenario5SaveChar(string Ranks)
        {
            ResultBase result = new ResultBase() { };
            try
            {
                var AllRank = JsonConvert.DeserializeObject<List<string>>(Ranks);
                AllRank.ForEach(x =>
                {
                    //Get user sn and value in string, spread by ',', first is UserSN, second is Handle job detail.
                    var RankArr = x.Split(new char[] { ',' }, 2);
                    DbScenarioCharValueRankModel model = new DbScenarioCharValueRankModel()
                    {
                        Rank = Convert.ToInt32(RankArr[1]),
                        ScenarioCharValueSN = Convert.ToInt32(RankArr[0]),
                        UserSN = sessionData.trading.sn
                    };
                    dbScenario.InsertOrReplaceScenarioCharRank(model);
                });
                result.setMessage("Done");
            }
            catch (Exception ex)
            {
                result.setException(ex, "Scenario5Save");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        #region Goto Scenario start
        [HttpPost]
        public JsonResult GotoScenario1(int TopicSN)
        {
            int GotoStep = 31;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<DbTopicMemberModel> TeamMembers;
            result = TopicServiceController.ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoScenario2(int TopicSN)
        {
            int GotoStep = 32;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<DbTopicMemberModel> TeamMembers;
            result = TopicServiceController.ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoScenario3(int TopicSN)
        {
            int GotoStep = 33;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<DbTopicMemberModel> TeamMembers;
            result = TopicServiceController.ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoScenario4(int TopicSN)
        {
            int GotoStep = 34;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<DbTopicMemberModel> TeamMembers;
            result = TopicServiceController.ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoScenario5(int TopicSN)
        {
            int GotoStep = 35;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<DbTopicMemberModel> TeamMembers;
            result = TopicServiceController.ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoScenario6(int TopicSN)
        {
            int GotoStep = 36;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<DbTopicMemberModel> TeamMembers;
            result = TopicServiceController.ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GotoScenario7(int TopicSN)
        {
            int GotoStep = 37;
            ResultBase result = new ResultBase() { };
            //Check the Leader
            List<DbTopicMemberModel> TeamMembers;
            result = TopicServiceController.ProcessGotoStep(TopicSN, GotoStep, sessionData.trading, out TeamMembers);
            return Json(result, JsonRequestBehavior.DenyGet);
        }
        #endregion
    }
}
