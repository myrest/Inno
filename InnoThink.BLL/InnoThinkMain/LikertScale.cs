using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.LikertScale;
using InnoThink.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;
using InnoThink.Domain.Constancy;
using InnoThink.Domain.InnoThinkMain.Binding;

namespace InnoThink.BLL.LikertScale
{
    /*
    #region interface
    public interface ILikertScale_Manager
    {
        LikertScale_Info GetBySN(long LikertScaleSN);
        IEnumerable<LikertScale_Info> GetAll();
        IEnumerable<LikertScale_Info> GetByParameter(LikertScale_Filter Filter, string _orderby = "");
        long Insert(LikertScale_Info data);
        bool Update(long LikertScaleSN, LikertScale_Info data, IEnumerable<string> columns);
        bool Update(LikertScale_Info data);
        int Delete(long LikertScaleSN);
        bool IsExist(long LikertScaleSN);
    }
    #endregion
    */
    #region implementation
    public class LikertScale_Manager //: ILikertScale_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(LikertScale_Manager));
        #endregion

        #region Operation: Select
        public LikertScale_Info GetBySN(long LikertScaleSN)
        {
            return new LikertScale_Repo().GetBySN(LikertScaleSN);
        }

        public IEnumerable<LikertScale_Info> GetAll()
        {
            return new LikertScale_Repo().GetAll();
        }

        public IEnumerable<LikertScale_Info> GetByParameter(LikertScale_Filter Filter, string _orderby = "")
        {
            return new LikertScale_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(LikertScale_Info data)
        {
            long newID = 0;
            try
            {
                newID = new LikertScale_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }

        public bool InsertBatch(List<LikerScaleBatchUpdateObject> data)
        {
            bool rtn = new LikertScale_Repo().InsertBatch(data);
            return rtn;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long LikertScaleSN, LikertScale_Info data, IEnumerable<string> columns)
        {
            return new LikertScale_Repo().Update(LikertScaleSN, data, columns) > 0;
        }

        public bool Update(LikertScale_Info data)
        {
            return new LikertScale_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long LikertScaleSN)
        {
            return new LikertScale_Repo().Delete(LikertScaleSN);
        }
        #endregion

        #region public functions
        public bool IsExist(long LikertScaleSN)
        {
            return (GetBySN(LikertScaleSN) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}