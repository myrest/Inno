using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.BestIdeaGroup;
using InnoThink.Domain.BestIdeaGroup;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.BestIdeaGroup
{
    #region interface
    public interface IBestIdeaGroup_Manager
    {
        BestIdeaGroup_Info GetByID(long SN);
        IEnumerable<BestIdeaGroup_Info> GetAll();
        IEnumerable<BestIdeaGroup_Info> GetByParameter(BestIdeaGroup_Filter Filter, string _orderby = "");
        long Insert(BestIdeaGroup_Info data);
        bool Update(long SN, BestIdeaGroup_Info data, IEnumerable<string> columns);
        int Delete(long SN);
        bool IsExist(long SN);
    }
    #endregion

    #region implementation
    public class BestIdeaGroup_Manager : IBestIdeaGroup_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(BestIdeaGroup_Manager));
        #endregion

        #region Operation: Select
        public BestIdeaGroup_Info GetByID(long SN)
        {
            return new BestIdeaGroup_Repo().GetByID(SN);
        }

        public IEnumerable<BestIdeaGroup_Info> GetAll()
        {
            return new BestIdeaGroup_Repo().GetAll();
        }

        public IEnumerable<BestIdeaGroup_Info> GetByParameter(BestIdeaGroup_Filter Filter, string _orderby = "")
        {
            return new BestIdeaGroup_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(BestIdeaGroup_Info data)
        {
            long newID = 0;
            try
            {
                newID = new BestIdeaGroup_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long SN, BestIdeaGroup_Info data, IEnumerable<string> columns)
        {
            return new BestIdeaGroup_Repo().Update(SN, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long SN)
        {
            return new BestIdeaGroup_Repo().Delete(SN);
        }
        #endregion

        #region public functions
        public bool IsExist(long SN)
        {
            return (GetByID(SN) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}