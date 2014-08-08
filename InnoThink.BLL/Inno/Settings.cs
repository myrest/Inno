using InnoThink.DAL.Settings;
using InnoThink.Domain.Settings;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

namespace InnoThink.BLL.Settings
{
    #region interface

    public interface ISettings_Manager
    {
        Settings_Info GetByID(long NoPk);

        IEnumerable<Settings_Info> GetAll();

        IEnumerable<Settings_Info> GetByParameter(Settings_Filter Filter, string _orderby = "");

        long Insert(Settings_Info data);

        bool Update(long NoPk, Settings_Info data, IEnumerable<string> columns);

        int Delete(long NoPk);

        bool IsExist(long NoPk);
    }

    #endregion interface

    #region implementation

    public class Settings_Manager : ISettings_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(Settings_Manager));

        #endregion private fields

        #region Operation: Select

        public Settings_Info GetByID(long NoPk)
        {
            return new Settings_Repo().GetByID(NoPk);
        }

        public IEnumerable<Settings_Info> GetAll()
        {
            return new Settings_Repo().GetAll();
        }

        public IEnumerable<Settings_Info> GetByParameter(Settings_Filter Filter, string _orderby = "")
        {
            return new Settings_Repo().GetByParam(Filter, _orderby);
        }

        #endregion Operation: Select

        #region Operation: Raw Insert

        public long Insert(Settings_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Settings_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long NoPk, Settings_Info data, IEnumerable<string> columns)
        {
            return new Settings_Repo().Update(NoPk, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long NoPk)
        {
            return new Settings_Repo().Delete(NoPk);
        }

        #endregion Operation: Delete

        #region public functions

        public bool IsExist(long NoPk)
        {
            return (GetByID(NoPk) != null);
        }

        #endregion public functions
    }

    #endregion implementation
}