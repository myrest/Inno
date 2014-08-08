using InnoThink.DAL.ResultsRank;
using InnoThink.Domain.ResultsRank;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

namespace InnoThink.BLL.ResultsRank
{
    #region interface

    public interface IResultsRank_Manager
    {
        ResultsRank_Info GetByID(long NoPk);

        IEnumerable<ResultsRank_Info> GetAll();

        IEnumerable<ResultsRank_Info> GetByParameter(ResultsRank_Filter Filter, string _orderby = "");

        long Insert(ResultsRank_Info data);

        bool Update(long NoPk, ResultsRank_Info data, IEnumerable<string> columns);

        int Delete(long NoPk);

        bool IsExist(long NoPk);
    }

    #endregion interface

    #region implementation

    public class ResultsRank_Manager : IResultsRank_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(ResultsRank_Manager));

        #endregion private fields

        #region Operation: Select

        public ResultsRank_Info GetByID(long NoPk)
        {
            return new ResultsRank_Repo().GetByID(NoPk);
        }

        public IEnumerable<ResultsRank_Info> GetAll()
        {
            return new ResultsRank_Repo().GetAll();
        }

        public IEnumerable<ResultsRank_Info> GetByParameter(ResultsRank_Filter Filter, string _orderby = "")
        {
            return new ResultsRank_Repo().GetByParam(Filter, _orderby);
        }

        #endregion Operation: Select

        #region Operation: Raw Insert

        public long Insert(ResultsRank_Info data)
        {
            long newID = 0;
            try
            {
                newID = new ResultsRank_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long NoPk, ResultsRank_Info data, IEnumerable<string> columns)
        {
            return new ResultsRank_Repo().Update(NoPk, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long NoPk)
        {
            return new ResultsRank_Repo().Delete(NoPk);
        }

        #endregion Operation: Delete

        #region public functions

        public bool IsExist(long NoPk)
        {
            return (GetByID(NoPk) != null);
        }

        #endregion public functions
    }

    #endregion implementation
}