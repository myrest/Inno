using InnoThink.Domain;
using InnoThink.Domain.TeamGroup;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.DAL.TeamGroup
{
    #region interface
    public interface ITeamGroup_Repo
    {
        TeamGroup_Info GetBySN(long TeamGroupSN);
        IEnumerable<TeamGroup_Info> GetAll();
        IEnumerable<TeamGroup_Info> GetByParam(TeamGroup_Filter Filter, string _orderby = "");
        IEnumerable<TeamGroup_Info> GetByParam(TeamGroup_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(TeamGroup_Info data);
        int Update(long TeamGroupSN, TeamGroup_Info data, IEnumerable<string> columns);
        int Update(TeamGroup_Info data);
        int Delete(long TeamGroupSN);
    }
    #endregion

    #region Implementation
    public class TeamGroup_Repo
    {
        #region Operation: Select
        public TeamGroup_Info GetBySN(long TeamGroupSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM TeamGroup")
                .Append("WHERE TeamGroupSN=@0", TeamGroupSN);

                var result = db.SingleOrDefault<TeamGroup_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<TeamGroup_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM TeamGroup");
                var result = db.Query<TeamGroup_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<TeamGroup_Info> GetByParam(TeamGroup_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<TeamGroup_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<TeamGroup_Info> GetByParam(TeamGroup_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<TeamGroup_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(TeamGroup_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long TeamGroupSN, TeamGroup_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, TeamGroupSN, columns);
            }
        }

        public int Update(TeamGroup_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long TeamGroupSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("TeamGroup", "TeamGroupSN", null, TeamGroupSN);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(TeamGroup_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(TeamGroup_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM TeamGroup")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                //if (filter.ID != 0)
                    //SQLStr.Append(" AND TeamGroupSN=@0", filter.ID);
                    //Should updat the filter for wide search

                if (_orderby != "")
                    SQLStr.Append("ORDER BY @0", _orderby);

            }
            return SQLStr;
        }

        private string FieldNameArrayToFieldNameString(string[] fieldNames)
        {
            return string.Join(", ", fieldNames);
        }
        #endregion
    }
    #endregion

}