using InnoThink.DAL.TeamGroup;
using InnoThink.Domain.TeamGroup;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

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

    #endregion interface

    #region implementation

    public class TeamGroup_Manager : ITeamGroup_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(TeamGroup_Manager));

        #endregion private fields

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

        #endregion Operation: Select

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

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long SN, TeamGroup_Info data, IEnumerable<string> columns)
        {
            return new TeamGroup_Repo().Update(SN, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long SN)
        {
            return new TeamGroup_Repo().Delete(SN);
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