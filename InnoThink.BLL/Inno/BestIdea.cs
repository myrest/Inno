using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.BestIdea;
using InnoThink.Domain.BestIdea;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.BestIdea
{
    #region interface
    public interface IBestIdea_Manager
    {
        BestIdea_Info GetByID(long SN);
        IEnumerable<BestIdea_Info> GetAll();
        IEnumerable<BestIdea_Info> GetByParameter(BestIdea_Filter Filter, string _orderby = "");
        long Insert(BestIdea_Info data);
        bool Update(long SN, BestIdea_Info data, IEnumerable<string> columns);
        int Delete(long SN);
        bool IsExist(long SN);
    }
    #endregion

    #region implementation
    public class BestIdea_Manager : IBestIdea_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(BestIdea_Manager));
        #endregion

        #region Operation: Select
        public BestIdea_Info GetByID(long SN)
        {
            return new BestIdea_Repo().GetByID(SN);
        }

        public IEnumerable<BestIdea_Info> GetAll()
        {
            return new BestIdea_Repo().GetAll();
        }

        public IEnumerable<BestIdea_Info> GetByParameter(BestIdea_Filter Filter, string _orderby = "")
        {
            return new BestIdea_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(BestIdea_Info data)
        {
            long newID = 0;
            try
            {
                newID = new BestIdea_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long SN, BestIdea_Info data, IEnumerable<string> columns)
        {
            return new BestIdea_Repo().Update(SN, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long SN)
        {
            return new BestIdea_Repo().Delete(SN);
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