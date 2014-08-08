namespace InnoThink.Domain.Settings
{
    #region interface

    public interface ISettings_Info
    {
        string Key { get; set; }

        string LastUpdate { get; set; }

        string Para { get; set; }

        string Value { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("Settings")]
    [Rest.Core.PetaPoco.PrimaryKey("")]
    public class Settings_Info : ISettings_Info
    {
        #region private fields

        public string Key { get; set; }

        public string LastUpdate { get; set; }

        public string Para { get; set; }

        public string Value { get; set; }

        #endregion private fields

        #region Constructor

        public Settings_Info()
        {
        }

        #endregion Constructor
    }

    public class Settings_Filter
    {
        //You can copy above Settings_Info field for search criteria
    }

    #endregion Implementation
}