using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.Topic;
using InnoThink.Domain.Topic;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.Topic
{
    #region interface
    public interface ITopic_Manager
    {
        Topic_Info GetByID(long SN);
        IEnumerable<Topic_Info> GetAll();
        IEnumerable<Topic_Info> GetByParameter(Topic_Filter Filter, string _orderby = "");
        long Insert(Topic_Info data);
        bool Update(long SN, Topic_Info data, IEnumerable<string> columns);
        int Delete(long SN);
        bool IsExist(long SN);
    }
    #endregion

    #region implementation
    public class Topic_Manager : ITopic_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Topic_Manager));
        #endregion

        #region Operation: Select
        public Topic_Info GetByID(long SN)
        {
            return new Topic_Repo().GetByID(SN);
        }

        public IEnumerable<Topic_Info> GetAll()
        {
            return new Topic_Repo().GetAll();
        }

        public IEnumerable<Topic_Info> GetByParameter(Topic_Filter Filter, string _orderby = "")
        {
            return new Topic_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Topic_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Topic_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long SN, Topic_Info data, IEnumerable<string> columns)
        {
            return new Topic_Repo().Update(SN, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long SN)
        {
            return new Topic_Repo().Delete(SN);
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