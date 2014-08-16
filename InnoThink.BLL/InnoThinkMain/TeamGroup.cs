using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.TeamGroup;
using InnoThink.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.TeamGroup
{
    /*
    #region interface
    public interface ITeamGroup_Manager
    {
        TeamGroup_Info GetBySN(long TeamGroupSN);
        IEnumerable<TeamGroup_Info> GetAll();
        IEnumerable<TeamGroup_Info> GetByParameter(TeamGroup_Filter Filter, string _orderby = "");
        long Insert(TeamGroup_Info data);
        bool Update(long TeamGroupSN, TeamGroup_Info data, IEnumerable<string> columns);
        bool Update(TeamGroup_Info data);
        int Delete(long TeamGroupSN);
        bool IsExist(long TeamGroupSN);
    }
    #endregion
    */
    #region implementation
    public class TeamGroup_Manager //: ITeamGroup_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(TeamGroup_Manager));
        #endregion

        #region Operation: Select
        public TeamGroup_Info GetBySN(long TeamGroupSN)
        {
            return new TeamGroup_Repo().GetBySN(TeamGroupSN);
        }

        public IEnumerable<TeamGroup_Info> GetAll()
        {
            return new TeamGroup_Repo().GetAll();
        }

        public IEnumerable<TeamGroup_Info> GetByParameter(TeamGroup_Filter Filter, string _orderby = "")
        {
            return new TeamGroup_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(TeamGroup_Info data)
        {
            long newID = 0;
            try
            {
                newID = new TeamGroup_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long TeamGroupSN, TeamGroup_Info data, IEnumerable<string> columns)
        {
            return new TeamGroup_Repo().Update(TeamGroupSN, data, columns) > 0;
        }

        public bool Update(TeamGroup_Info data)
        {
            return new TeamGroup_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long TeamGroupSN)
        {
            return new TeamGroup_Repo().Delete(TeamGroupSN);
        }
        #endregion

        #region public functions
        public bool IsExist(long TeamGroupSN)
        {
            return (GetBySN(TeamGroupSN) != null);
        }
        #endregion

        #region private functions
        #endregion

        public bool CheckNameIsExist(string TeamGroupName)
        {
            var rep = new TeamGroup_Repo();
            var data = rep.GetByParam(new TeamGroup_Filter()
            {
                GroupName = TeamGroupName
            }).FirstOrDefault();
            return (data != null);
        }
    }
    #endregion
}