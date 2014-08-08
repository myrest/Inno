using InnoThink.DAL.TopicMember;
using InnoThink.Domain.TopicMember;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

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

    #endregion interface

    #region implementation

    public class TopicMember_Manager : ITopicMember_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(TopicMember_Manager));

        #endregion private fields

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

        #endregion Operation: Select

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

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long SN, TopicMember_Info data, IEnumerable<string> columns)
        {
            return new TopicMember_Repo().Update(SN, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long SN)
        {
            return new TopicMember_Repo().Delete(SN);
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