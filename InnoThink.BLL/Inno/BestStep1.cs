using InnoThink.DAL.BestStep1;
using InnoThink.Domain.BestStep1;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

namespace InnoThink.BLL.BestStep1
{
    #region interface

    public interface IBestStep1_Manager
    {
        BestStep1_Info GetByID(long SN);

        IEnumerable<BestStep1_Info> GetAll();

        IEnumerable<BestStep1_Info> GetByParameter(BestStep1_Filter Filter, string _orderby = "");

        long Insert(BestStep1_Info data);

        bool Update(long SN, BestStep1_Info data, IEnumerable<string> columns);

        int Delete(long SN);

        bool IsExist(long SN);
    }

    #endregion interface

    #region implementation

    public class BestStep1_Manager : IBestStep1_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(BestStep1_Manager));

        #endregion private fields

        #region Operation: Select

        public BestStep1_Info GetByID(long SN)
        {
            return new BestStep1_Repo().GetByID(SN);
        }

        public IEnumerable<BestStep1_Info> GetAll()
        {
            return new BestStep1_Repo().GetAll();
        }

        public IEnumerable<BestStep1_Info> GetByParameter(BestStep1_Filter Filter, string _orderby = "")
        {
            return new BestStep1_Repo().GetByParam(Filter, _orderby);
        }

        #endregion Operation: Select

        #region Operation: Raw Insert

        public long Insert(BestStep1_Info data)
        {
            long newID = 0;
            try
            {
                newID = new BestStep1_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long SN, BestStep1_Info data, IEnumerable<string> columns)
        {
            return new BestStep1_Repo().Update(SN, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long SN)
        {
            return new BestStep1_Repo().Delete(SN);
        }

        #endregion Operation: Delete

        #region public functions

        public bool IsExist(long SN)
        {
            return (GetByID(SN) != null);
        }

        #endregion public functions
    }

    #endregion implementation
}