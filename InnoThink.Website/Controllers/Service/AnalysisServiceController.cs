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
        }

        [HttpPost]
        public JsonResult NewAnalysis(AnalysisUIPara para)
        {
            var result = InsertIntoAnalysis(para);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        //Accroding user's input, insert into Database of Analysis.
        private ResultBase InsertIntoAnalysis(AnalysisUIPara para)
        {
            ResultBase result = new ResultBase() { };
            Analysis_Info data = new Analysis_Info()
            {
                AnalysisType = para.Type,
                Column1 = para.Idea,
                Column2 = para.Description,
                TopicSN = para.TopicSN,
                UserSN = sessionData.trading.UserSN
            };
            long newId = dbAnalysis.Insert(data);
            if (newId > 0)
            {
                result.setMessage("Done");
            }
            else
            {
                result.setErrorMessage("Insert new data hit error at NewAnalysis.");
            }
            return result;
        }

    }
}
