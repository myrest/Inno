using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.Topic;
using InnoThink.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;
using InnoThink.Domain.InnoThinkMain.Binding;
using InnoThink.DAL.TopicMember;

namespace InnoThink.BLL.Topic
{
    /*
    #region interface
    public interface ITopic_Manager
    {
        Topic_Info GetBySN(long TopicSN);
        IEnumerable<Topic_Info> GetAll();
        IEnumerable<Topic_Info> GetByParameter(Topic_Filter Filter, string _orderby = "");
        long Insert(Topic_Info data);
        bool Update(long TopicSN, Topic_Info data, IEnumerable<string> columns);
        bool Update(Topic_Info data);
        int Delete(long TopicSN);
        bool IsExist(long TopicSN);
    }
    #endregion
    */
    #region implementation
    public class Topic_Manager //: ITopic_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Topic_Manager));
        #endregion

        #region Operation: Select
        public Topic_Info GetBySN(long TopicSN)
        {
            return new Topic_Repo().GetBySN(TopicSN);
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
        public bool Update(long TopicSN, Topic_Info data, IEnumerable<string> columns)
        {
            return new Topic_Repo().Update(TopicSN, data, columns) > 0;
        }

        public bool Update(Topic_Info data)
        {
            return new Topic_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long TopicSN)
        {
            return new Topic_Repo().Delete(TopicSN);
        }
        #endregion

        #region public functions
        public bool IsExist(long TopicSN)
        {
            return (GetBySN(TopicSN) != null);
        }
        #endregion

        #region private functions
        #endregion

        public object IsTeamMember(int TopicSN, int p)
        {
            throw new NotImplementedException();
            /*
             * 
             *             Dictionary<string, string> paras = new Dictionary<string, string>() { };
            paras.Add("TopicSN", TopicSN.ToString());
            paras.Add("UsersSN", UserSN.ToString());
            int count = ExecuteReaderCount("TopicMember", paras);
            return (count > 0);
*/
        }
    }
    #endregion
}