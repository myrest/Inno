using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.TeamGroup;
using InnoThink.Domain.TeamGroup;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.TeamGroup
{
    #region interface
    public interface ITeamGroup_Manager
    {
        TeamGroup_Info GetByID(long SN);
        IEnumerable<TeamGroup_Info> GetAll();
        IEnumerable<TeamGroup_Info> GetByParameter(TeamGroup_Filter Filter, string _orderby = "");
        long Insert(TeamGroup_Info data);
        bool Update(long SN, TeamGroup_Info data, IEnumerable<string> columns);
        int Delete(long SN);
        bool IsExist(long SN);
    }
    #endregion

    #region implementation
    public class TeamGroup_Manager : ITeamGroup_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(TeamGroup_Manager));
        #endregion

        #region Operation: Select
        public TeamGroup_Info GetByID(long SN)
        {
            return new TeamGroup_Repo().GetByID(SN);
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
        public bool Update(long SN, TeamGroup_Info data, IEnumerable<string> columns)
        {
            return new TeamGroup_Repo().Update(SN, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long SN)
        {
            return new TeamGroup_Repo().Delete(SN);
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