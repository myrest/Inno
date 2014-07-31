using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.TopicMember;
using InnoThink.Domain.TopicMember;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.TopicMember
{
    #region interface
    public interface ITopicMember_Manager
    {
        TopicMember_Info GetByID(long SN);
        IEnumerable<TopicMember_Info> GetAll();
        IEnumerable<TopicMember_Info> GetByParameter(TopicMember_Filter Filter, string _orderby = "");
        long Insert(TopicMember_Info data);
        bool Update(long SN, TopicMember_Info data, IEnumerable<string> columns);
        int Delete(long SN);
        bool IsExist(long SN);
    }
    #endregion

    #region implementation
    public class TopicMember_Manager : ITopicMember_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(TopicMember_Manager));
        #endregion

        #region Operation: Select
        public TopicMember_Info GetByID(long SN)
        {
            return new TopicMember_Repo().GetByID(SN);
        }

        public IEnumerable<TopicMember_Info> GetAll()
        {
            return new TopicMember_Repo().GetAll();
        }

        public IEnumerable<TopicMember_Info> GetByParameter(TopicMember_Filter Filter, string _orderby = "")
        {
            return new TopicMember_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(TopicMember_Info data)
        {
            long newID = 0;
            try
            {
                newID = new TopicMember_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long SN, TopicMember_Info data, IEnumerable<string> columns)
        {
            return new TopicMember_Repo().Update(SN, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long SN)
        {
            return new TopicMember_Repo().Delete(SN);
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