using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain
{
    /*
    #region interface
    public interface IAnalysis_Info
    {
        int AnalysisSN { get; set; }
        int AnalysisType { get; set; }
        string Column1 { get; set; }
        string Column2 { get; set; }
        string Column3 { get; set; }
        string Column4 { get; set; }
        int IsImage { get; set; }
        DateTime LastUpdate { get; set; }
        string ServerFileName { get; set; }
        int TopicSN { get; set; }
        string UserFileName { get; set; }
        int UserSN { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("Analysis")]
    [Rest.Core.PetaPoco.PrimaryKey("AnalysisSN")]
    public class Analysis_Info //: IAnalysis_Info
    {
        #region private fields
        public int AnalysisSN { get; set; }
        public int AnalysisType { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public int IsImage { get; set; }
        public DateTime LastUpdate { get; set; }
        public string ServerFileName { get; set; }
        public int TopicSN { get; set; }
        public string UserFileName { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public Analysis_Info()
        {
            LastUpdate = DateTime.Now;
        }
        #endregion
    }

    public class Analysis_Filter
    {
        public int? AnalysisSN { get; set; }
        public int? AnalysisType { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public int? IsImage { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string ServerFileName { get; set; }
        public int? TopicSN { get; set; }
        public string UserFileName { get; set; }
        public int? UserSN { get; set; }
        //You can copy/modify above Analysis_Info field for search criteria
    }
    #endregion
}