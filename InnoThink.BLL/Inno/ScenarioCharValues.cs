using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.ScenarioCharValues;
using InnoThink.Domain.ScenarioCharValues;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.ScenarioCharValues
{
    #region interface
    public interface IScenarioCharValues_Manager
    {
        ScenarioCharValues_Info GetByID(long SN);
        IEnumerable<ScenarioCharValues_Info> GetAll();
        IEnumerable<ScenarioCharValues_Info> GetByParameter(ScenarioCharValues_Filter Filter, string _orderby = "");
        long Insert(ScenarioCharValues_Info data);
        bool Update(long SN, ScenarioCharValues_Info data, IEnumerable<string> columns);
        int Delete(long SN);
        bool IsExist(long SN);
    }
    #endregion

    #region implementation
    public class ScenarioCharValues_Manager : IScenarioCharValues_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(ScenarioCharValues_Manager));
        #endregion

        #region Operation: Select
        public ScenarioCharValues_Info GetByID(long SN)
        {
            return new ScenarioCharValues_Repo().GetByID(SN);
        }

        public IEnumerable<ScenarioCharValues_Info> GetAll()
        {
            return new ScenarioCharValues_Repo().GetAll();
        }

        public IEnumerable<ScenarioCharValues_Info> GetByParameter(ScenarioCharValues_Filter Filter, string _orderby = "")
        {
            return new ScenarioCharValues_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(ScenarioCharValues_Info data)
        {
            long newID = 0;
            try
            {
                newID = new ScenarioCharValues_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long SN, ScenarioCharValues_Info data, IEnumerable<string> columns)
        {
            return new ScenarioCharValues_Repo().Update(SN, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long SN)
        {
            return new ScenarioCharValues_Repo().Delete(SN);
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