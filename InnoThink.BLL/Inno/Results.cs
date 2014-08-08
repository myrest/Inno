using InnoThink.DAL.Results;
using InnoThink.Domain.Results;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

namespace InnoThink.BLL.Results
{
    #region interface

    public interface IResults_Manager
    {
        Results_Info GetByID(long SN);

        IEnumerable<Results_Info> GetAll();

        IEnumerable<Results_Info> GetByParameter(Results_Filter Filter, string _orderby = "");

        long Insert(Results_Info data);

        bool Update(long SN, Results_Info data, IEnumerable<string> columns);

        int Delete(long SN);

        bool IsExist(long SN);
    }

    #endregion interface

    #region implementation

    public class Results_Manager : IResults_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(Results_Manager));

        #endregion private fields

        #region Operation: Select

        public Results_Info GetByID(long SN)
        {
            return new Results_Repo().GetByID(SN);
        }

        public IEnumerable<Results_Info> GetAll()
        {
            return new Results_Repo().GetAll();
        }

        public IEnumerable<Results_Info> GetByParameter(Results_Filter Filter, string _orderby = "")
        {
            return new Results_Repo().GetByParam(Filter, _orderby);
        }

        #endregion Operation: Select

        #region Operation: Raw Insert

        public long Insert(Results_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Results_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long SN, Results_Info data, IEnumerable<string> columns)
        {
            return new Results_Repo().Update(SN, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long SN)
        {
            return new Results_Repo().Delete(SN);
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