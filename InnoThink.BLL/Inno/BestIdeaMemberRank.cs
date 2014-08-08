using InnoThink.DAL.BestIdeaMemberRank;
using InnoThink.Domain.BestIdeaMemberRank;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

namespace InnoThink.BLL.BestIdeaMemberRank
{
    #region interface

    public interface IBestIdeaMemberRank_Manager
    {
        BestIdeaMemberRank_Info GetByID(long NoPk);

        IEnumerable<BestIdeaMemberRank_Info> GetAll();

        IEnumerable<BestIdeaMemberRank_Info> GetByParameter(BestIdeaMemberRank_Filter Filter, string _orderby = "");

        long Insert(BestIdeaMemberRank_Info data);

        bool Update(long NoPk, BestIdeaMemberRank_Info data, IEnumerable<string> columns);

        int Delete(long NoPk);

        bool IsExist(long NoPk);
    }

    #endregion interface

    #region implementation

    public class BestIdeaMemberRank_Manager : IBestIdeaMemberRank_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(BestIdeaMemberRank_Manager));

        #endregion private fields

        #region Operation: Select

        public BestIdeaMemberRank_Info GetByID(long NoPk)
        {
            return new BestIdeaMemberRank_Repo().GetByID(NoPk);
        }

        public IEnumerable<BestIdeaMemberRank_Info> GetAll()
        {
            return new BestIdeaMemberRank_Repo().GetAll();
        }

        public IEnumerable<BestIdeaMemberRank_Info> GetByParameter(BestIdeaMemberRank_Filter Filter, string _orderby = "")
        {
            return new BestIdeaMemberRank_Repo().GetByParam(Filter, _orderby);
        }

        #endregion Operation: Select

        #region Operation: Raw Insert

        public long Insert(BestIdeaMemberRank_Info data)
        {
            long newID = 0;
            try
            {
                newID = new BestIdeaMemberRank_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long NoPk, BestIdeaMemberRank_Info data, IEnumerable<string> columns)
        {
            return new BestIdeaMemberRank_Repo().Update(NoPk, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long NoPk)
        {
            return new BestIdeaMemberRank_Repo().Delete(NoPk);
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