using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.Analysis;
using InnoThink.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;
using InnoThink.Domain.Constancy;

namespace InnoThink.BLL.Analysis
{
    /*
    #region interface
    public interface IAnalysis_Manager
    {
        Analysis_Info GetBySN(long AnalysisSN);
        IEnumerable<Analysis_Info> GetAll();
        IEnumerable<Analysis_Info> GetByParameter(Analysis_Filter Filter, string _orderby = "");
        long Insert(Analysis_Info data);
        bool Update(long AnalysisSN, Analysis_Info data, IEnumerable<string> columns);
        bool Update(Analysis_Info data);
        int Delete(long AnalysisSN);
        bool IsExist(long AnalysisSN);
    }
    #endregion
    */
    #region implementation
    public class Analysis_Manager //: IAnalysis_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Analysis_Manager));
        #endregion

        #region Operation: Select
        public Analysis_Info GetBySN(long AnalysisSN)
        {
            return new Analysis_Repo().GetBySN(AnalysisSN);
        }

        public IEnumerable<Analysis_Info> GetAll()
        {
            return new Analysis_Repo().GetAll();
        }

        public IEnumerable<Analysis_Info> GetByParameter(Analysis_Filter Filter, string _orderby = "")
        {
            return new Analysis_Repo().GetByParam(Filter, _orderby);
        }

        public List<Analysis_Info> GetByTopicSN(int TopicSN, EnumAnalyticsType type)
        {
            return new Analysis_Repo().GetByParam(new Analysis_Filter()
            {
                TopicSN = TopicSN,
                AnalysisType = (int)type
            }).ToList();
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Analysis_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Analysis_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long AnalysisSN, Analysis_Info data, IEnumerable<string> columns)
        {
            return new Analysis_Repo().Update(AnalysisSN, data, columns) > 0;
        }

        public bool Update(Analysis_Info data)
        {
            return new Analysis_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AnalysisSN)
        {
            return new Analysis_Repo().Delete(AnalysisSN);
        }
        #endregion

        #region public functions
        public bool IsExist(long AnalysisSN)
        {
            return (GetBySN(AnalysisSN) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}