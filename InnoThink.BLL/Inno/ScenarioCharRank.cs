using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.ScenarioCharRank;
using InnoThink.Domain.ScenarioCharRank;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.ScenarioCharRank
{
    #region interface
    public interface IScenarioCharRank_Manager
    {
        ScenarioCharRank_Info GetByID(long NoPk);
        IEnumerable<ScenarioCharRank_Info> GetAll();
        IEnumerable<ScenarioCharRank_Info> GetByParameter(ScenarioCharRank_Filter Filter, string _orderby = "");
        long Insert(ScenarioCharRank_Info data);
        bool Update(long NoPk, ScenarioCharRank_Info data, IEnumerable<string> columns);
        int Delete(long NoPk);
        bool IsExist(long NoPk);
    }
    #endregion

    #region implementation
    public class ScenarioCharRank_Manager : IScenarioCharRank_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(ScenarioCharRank_Manager));
        #endregion

        #region Operation: Select
        public ScenarioCharRank_Info GetByID(long NoPk)
        {
            return new ScenarioCharRank_Repo().GetByID(NoPk);
        }

        public IEnumerable<ScenarioCharRank_Info> GetAll()
        {
            return new ScenarioCharRank_Repo().GetAll();
        }

        public IEnumerable<ScenarioCharRank_Info> GetByParameter(ScenarioCharRank_Filter Filter, string _orderby = "")
        {
            return new ScenarioCharRank_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(ScenarioCharRank_Info data)
        {
            long newID = 0;
            try
            {
                newID = new ScenarioCharRank_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long NoPk, ScenarioCharRank_Info data, IEnumerable<string> columns)
        {
            return new ScenarioCharRank_Repo().Update(NoPk, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NoPk)
        {
            return new ScenarioCharRank_Repo().Delete(NoPk);
        }
        #endregion

        #region public functions
        public bool IsExist(long NoPk)
        {
            return (GetByID(NoPk) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}