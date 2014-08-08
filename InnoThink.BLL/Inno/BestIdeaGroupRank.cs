using InnoThink.DAL.BestIdeaGroupRank;
using InnoThink.Domain.BestIdeaGroupRank;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

namespace InnoThink.BLL.BestIdeaGroupRank
{
    #region interface

    public interface IBestIdeaGroupRank_Manager
    {
        BestIdeaGroupRank_Info GetByID(long NoPk);

        IEnumerable<BestIdeaGroupRank_Info> GetAll();

        IEnumerable<BestIdeaGroupRank_Info> GetByParameter(BestIdeaGroupRank_Filter Filter, string _orderby = "");

        long Insert(BestIdeaGroupRank_Info data);

        bool Update(long NoPk, BestIdeaGroupRank_Info data, IEnumerable<string> columns);

        int Delete(long NoPk);

        bool IsExist(long NoPk);
    }

    #endregion interface

    #region implementation

    public class BestIdeaGroupRank_Manager : IBestIdeaGroupRank_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(BestIdeaGroupRank_Manager));

        #endregion private fields

        #region Operation: Select

        public BestIdeaGroupRank_Info GetByID(long NoPk)
        {
            return new BestIdeaGroupRank_Repo().GetByID(NoPk);
        }

        public IEnumerable<BestIdeaGroupRank_Info> GetAll()
        {
            return new BestIdeaGroupRank_Repo().GetAll();
        }

        public IEnumerable<BestIdeaGroupRank_Info> GetByParameter(BestIdeaGroupRank_Filter Filter, string _orderby = "")
        {
            return new BestIdeaGroupRank_Repo().GetByParam(Filter, _orderby);
        }

        #endregion Operation: Select

        #region Operation: Raw Insert

        public long Insert(BestIdeaGroupRank_Info data)
        {
            long newID = 0;
            try
            {
                newID = new BestIdeaGroupRank_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long NoPk, BestIdeaGroupRank_Info data, IEnumerable<string> columns)
        {
            return new BestIdeaGroupRank_Repo().Update(NoPk, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long NoPk)
        {
            return new BestIdeaGroupRank_Repo().Delete(NoPk);
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