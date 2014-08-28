using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InnoThink.Core.MVC.BaseController;
using Rest.Core.Utility;
using InnoThink.Core.Constancy;
using InnoThink.BLL.Analysis;
using InnoThink.Website.Models;
using InnoThink.Domain;
using InnoThink.Domain.Constancy;

namespace EShopManager.Website.Controllers.Service
{
    public class AnalysisServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(AnalysisServiceController));
        private static readonly Analysis_Manager dbAnalysis = new Analysis_Manager();

        public AnalysisServiceController()
            : base(Permission.Private)
        {
        }

        public class AnalysisUIPara
        {
            public int TopicSN { get; set; }
            public int Type { get; set; }
            public string Idea { get; set; }
            public string Description { get; set; }
            public int AnalysisSN { get; set; }
        }

        [HttpPost]
        public JsonResult SaveAnalysis(AnalysisUIPara para)
        {
            var result = InsertOrReplaceAnalysis(para);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        //Accroding user's input, insert into Database of Analysis.
        private ResultBase InsertOrReplaceAnalysis(AnalysisUIPara para)
        {
            ResultBase result = new ResultBase() { };
            Analysis_Info data = new Analysis_Info()
            {
                AnalysisType = para.Type,
                Column1 = para.Idea,
                Column2 = para.Description,
                TopicSN = para.TopicSN,
                UserSN = sessionData.trading.UserSN,
                AnalysisSN = para.AnalysisSN
            };
            long dbRtn = 0;
            if (data.AnalysisSN > 0)
            {
                dbRtn = dbAnalysis.Update(data) ? 1 : 0;
            }
            else
            {
                dbRtn = dbAnalysis.Insert(data);
            }
            if (dbRtn > 0)
            {
                result.setMessage("Done");
            }
            else
            {
                result.setErrorMessage("InsertOrReplaceAnalysis got error.");
            }
            return result;
        }

        [HttpPost]
        public JsonResult GetItemList(int TopicSN, int AnalysisType)
        {
            ResultModel<Analysis_Info> result = new ResultModel<Analysis_Info>() { };
            try
            {
                EnumAnalysisType anaType = (EnumAnalysisType)AnalysisType;
                var data = dbAnalysis.GetByTopicSN(TopicSN, anaType);
                result.Items = data;
                result.setMessage("");
            }
            catch (Exception ex)
            {
                result.setException(ex, "GetItemList");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult DeleteAnalysis(int AnalysisSN)
        {
            ResultBase result = new ResultBase();
            try
            {
                var data = dbAnalysis.Delete(AnalysisSN);
                result.setMessage("");
            }
            catch (Exception ex)
            {
                result.setException(ex, "DeleteAnalysis");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

    }
}
