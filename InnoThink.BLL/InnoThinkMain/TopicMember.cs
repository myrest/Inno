using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.TopicMember;
using InnoThink.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;
using InnoThink.Domain.InnoThinkMain.Binding;

namespace InnoThink.BLL.TopicMember
{
    /*
    #region interface
    public interface ITopicMember_Manager
    {
        TopicMember_Info GetBySN(long TopicMemberSN);
        IEnumerable<TopicMember_Info> GetAll();
        IEnumerable<TopicMember_Info> GetByParameter(TopicMember_Filter Filter, string _orderby = "");
        long Insert(TopicMember_Info data);
        bool Update(long TopicMemberSN, TopicMember_Info data, IEnumerable<string> columns);
        bool Update(TopicMember_Info data);
        int Delete(long TopicMemberSN);
        bool IsExist(long TopicMemberSN);
    }
    #endregion
    */
    #region implementation
    public class TopicMember_Manager //: ITopicMember_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(TopicMember_Manager));
        #endregion

        #region Operation: Select
        public TopicMember_Info GetBySN(long TopicMemberSN)
        {
            return new TopicMember_Repo().GetBySN(TopicMemberSN);
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
        public bool Update(long TopicMemberSN, TopicMember_Info data, IEnumerable<string> columns)
        {
            return new TopicMember_Repo().Update(TopicMemberSN, data, columns) > 0;
        }

        public bool Update(TopicMember_Info data)
        {
            return new TopicMember_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long TopicMemberSN)
        {
            return new TopicMember_Repo().Delete(TopicMemberSN);
        }
        #endregion

        #region public functions
        public bool IsExist(long TopicMemberSN)
        {
            return (GetBySN(TopicMemberSN) != null);
        }
        #endregion

        #region private functions
        #endregion

        public List<TopicMemberUI> getStep0Description(int TopicSN)
        {
            var rep = new TopicMember_Repo();
            return rep.getStep0Description(TopicSN);
        }

        public List<int> GetAllJoinedTopicByUserSN(int UserSN)
        {
            var rep = new TopicMember_Repo();
            List<TopicMemberUI> data = rep.GetAllJoinedTopicByUserSN(UserSN);
            if (data != null)
            {
                return data.Select(x => x.TopicSN).ToList();
            }
            else
            {
                return null;
            }
        }

        public TopicMember_Info getTopicMember(int TopicSN, int UserSN)
        {
            var rep = new TopicMember_Repo();
            List<TopicMemberUI> data = rep.getTopicMember(TopicSN, UserSN);
            if (data != null)
            {
                return data.First();
            }
            else
            {
                return null;
            }
        }

        public List<TopicMemberUI> getALLTopicMember(int TopicSN)
        {
            var rep = new TopicMember_Repo();
            List<TopicMemberUI> data = rep.getALLTopicMember(TopicSN);
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
    }
    #endregion
}