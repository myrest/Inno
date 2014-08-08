using InnoThink.DAL.BestIdea;
using InnoThink.Domain.BestIdea;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

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

    #endregion interface

    #region implementation

    public class BestIdea_Manager : IBestIdea_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(BestIdea_Manager));

        #endregion private fields

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

        #endregion Operation: Select

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

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long SN, BestIdea_Info data, IEnumerable<string> columns)
        {
            return new BestIdea_Repo().Update(SN, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long SN)
        {
            return new BestIdea_Repo().Delete(SN);
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