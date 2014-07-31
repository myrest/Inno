using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.BestIdeaGroupRank;
using InnoThink.Domain.BestIdeaGroupRank;
using Rest.Core.Constancy;
using Rest.Core.Utility;

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
    #endregion

    #region implementation
    public class BestIdeaGroupRank_Manager : IBestIdeaGroupRank_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(BestIdeaGroupRank_Manager));
        #endregion

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
        #endregion

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
        #endregion

        #region Operation: Raw Update
        public bool Update(long NoPk, BestIdeaGroupRank_Info data, IEnumerable<string> columns)
        {
            return new BestIdeaGroupRank_Repo().Update(NoPk, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NoPk)
        {
            return new BestIdeaGroupRank_Repo().Delete(NoPk);
        }
        #endregion

        #region public functions
        public bool IsExist(long NoPk)
        {
            return (GetByID(NoPk) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}