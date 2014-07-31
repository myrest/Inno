using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.ScenarioCharValuesRank;
using InnoThink.Domain.ScenarioCharValuesRank;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.ScenarioCharValuesRank
{
    #region interface
    public interface IScenarioCharValuesRank_Manager
    {
        ScenarioCharValuesRank_Info GetByID(long NoPk);
        IEnumerable<ScenarioCharValuesRank_Info> GetAll();
        IEnumerable<ScenarioCharValuesRank_Info> GetByParameter(ScenarioCharValuesRank_Filter Filter, string _orderby = "");
        long Insert(ScenarioCharValuesRank_Info data);
        bool Update(long NoPk, ScenarioCharValuesRank_Info data, IEnumerable<string> columns);
        int Delete(long NoPk);
        bool IsExist(long NoPk);
    }
    #endregion

    #region implementation
    public class ScenarioCharValuesRank_Manager : IScenarioCharValuesRank_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(ScenarioCharValuesRank_Manager));
        #endregion

        #region Operation: Select
        public ScenarioCharValuesRank_Info GetByID(long NoPk)
        {
            return new ScenarioCharValuesRank_Repo().GetByID(NoPk);
        }

        public IEnumerable<ScenarioCharValuesRank_Info> GetAll()
        {
            return new ScenarioCharValuesRank_Repo().GetAll();
        }

        public IEnumerable<ScenarioCharValuesRank_Info> GetByParameter(ScenarioCharValuesRank_Filter Filter, string _orderby = "")
        {
            return new ScenarioCharValuesRank_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(ScenarioCharValuesRank_Info data)
        {
            long newID = 0;
            try
            {
                newID = new ScenarioCharValuesRank_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long NoPk, ScenarioCharValuesRank_Info data, IEnumerable<string> columns)
        {
            return new ScenarioCharValuesRank_Repo().Update(NoPk, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NoPk)
        {
            return new ScenarioCharValuesRank_Repo().Delete(NoPk);
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