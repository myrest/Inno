using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.BestGAP;
using InnoThink.Domain.BestGAP;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.BestGAP
{
    #region interface
    public interface IBestGAP_Manager
    {
        BestGAP_Info GetByID(long SN);
        IEnumerable<BestGAP_Info> GetAll();
        IEnumerable<BestGAP_Info> GetByParameter(BestGAP_Filter Filter, string _orderby = "");
        long Insert(BestGAP_Info data);
        bool Update(long SN, BestGAP_Info data, IEnumerable<string> columns);
        int Delete(long SN);
        bool IsExist(long SN);
    }
    #endregion

    #region implementation
    public class BestGAP_Manager : IBestGAP_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(BestGAP_Manager));
        #endregion

        #region Operation: Select
        public BestGAP_Info GetByID(long SN)
        {
            return new BestGAP_Repo().GetByID(SN);
        }

        public IEnumerable<BestGAP_Info> GetAll()
        {
            return new BestGAP_Repo().GetAll();
        }

        public IEnumerable<BestGAP_Info> GetByParameter(BestGAP_Filter Filter, string _orderby = "")
        {
            return new BestGAP_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(BestGAP_Info data)
        {
            long newID = 0;
            try
            {
                newID = new BestGAP_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long SN, BestGAP_Info data, IEnumerable<string> columns)
        {
            return new BestGAP_Repo().Update(SN, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long SN)
        {
            return new BestGAP_Repo().Delete(SN);
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