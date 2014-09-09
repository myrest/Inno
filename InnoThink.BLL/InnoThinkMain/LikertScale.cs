using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.LikertScale;
using InnoThink.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;
using InnoThink.Domain.Constancy;

namespace InnoThink.BLL.LikertScale
{
    /*
    #region interface
    public interface ILikertScale_Manager
    {
        LikertScale_Info GetBySN(long NoPk);
        IEnumerable<LikertScale_Info> GetAll();
        IEnumerable<LikertScale_Info> GetByParameter(LikertScale_Filter Filter, string _orderby = "");
        long Insert(LikertScale_Info data);
        bool Update(long NoPk, LikertScale_Info data, IEnumerable<string> columns);
        bool Update(LikertScale_Info data);
        int Delete(long NoPk);
        bool IsExist(long NoPk);
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
        public LikertScale_Info GetBySN(long NoPk)
        {
            return new LikertScale_Repo().GetBySN(NoPk);
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
        #endregion

        #region Operation: Raw Update
        public bool Update(long NoPk, LikertScale_Info data, IEnumerable<string> columns)
        {
            return new LikertScale_Repo().Update(NoPk, data, columns) > 0;
        }

        public bool Update(LikertScale_Info data)
        {
            return new LikertScale_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NoPk)
        {
            return new LikertScale_Repo().Delete(NoPk);
        }
        #endregion

        #region public functions
        public bool IsExist(long NoPk)
        {
            return (GetBySN(NoPk) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}