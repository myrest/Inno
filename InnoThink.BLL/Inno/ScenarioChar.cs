using InnoThink.DAL.ScenarioChar;
using InnoThink.Domain.ScenarioChar;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

namespace InnoThink.BLL.ScenarioChar
{
    #region interface

    public interface IScenarioChar_Manager
    {
        ScenarioChar_Info GetByID(long SN);

        IEnumerable<ScenarioChar_Info> GetAll();

        IEnumerable<ScenarioChar_Info> GetByParameter(ScenarioChar_Filter Filter, string _orderby = "");

        long Insert(ScenarioChar_Info data);

        bool Update(long SN, ScenarioChar_Info data, IEnumerable<string> columns);

        int Delete(long SN);

        bool IsExist(long SN);
    }

    #endregion interface

    #region implementation

    public class ScenarioChar_Manager : IScenarioChar_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(ScenarioChar_Manager));

        #endregion private fields

        #region Operation: Select

        public ScenarioChar_Info GetByID(long SN)
        {
            return new ScenarioChar_Repo().GetByID(SN);
        }

        public IEnumerable<ScenarioChar_Info> GetAll()
        {
            return new ScenarioChar_Repo().GetAll();
        }

        public IEnumerable<ScenarioChar_Info> GetByParameter(ScenarioChar_Filter Filter, string _orderby = "")
        {
            return new ScenarioChar_Repo().GetByParam(Filter, _orderby);
        }

        #endregion Operation: Select

        #region Operation: Raw Insert

        public long Insert(ScenarioChar_Info data)
        {
            long newID = 0;
            try
            {
                newID = new ScenarioChar_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long SN, ScenarioChar_Info data, IEnumerable<string> columns)
        {
            return new ScenarioChar_Repo().Update(SN, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long SN)
        {
            return new ScenarioChar_Repo().Delete(SN);
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