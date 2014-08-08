using System;

namespace InnoThink.Domain.ScenarioChar
{
    #region interface

    public interface IScenarioChar_Info
    {
        int AgeRang { get; set; }

        DateTime Career { get; set; }

        int Edu { get; set; }

        int Gender { get; set; }

        int IsImage { get; set; }

        string LastUpdate { get; set; }

        string NickName { get; set; }

        string Personality { get; set; }

        int Salary { get; set; }

        int ScenarioType { get; set; }

        string ServerFileName { get; set; }

        int SN { get; set; }

        string Subject { get; set; }

        int TopicSN { get; set; }

        string UserFileName { get; set; }

        int UserSN { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("ScenarioChar")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class ScenarioChar_Info : IScenarioChar_Info
    {
        #region private fields

        public int AgeRang { get; set; }

        public DateTime Career { get; set; }

        public int Edu { get; set; }

        public int Gender { get; set; }

        public int IsImage { get; set; }

        public string LastUpdate { get; set; }

        public string NickName { get; set; }

        public string Personality { get; set; }

        public int Salary { get; set; }

        public int ScenarioType { get; set; }

        public string ServerFileName { get; set; }

        public int SN { get; set; }

        public string Subject { get; set; }

        public int TopicSN { get; set; }

        public string UserFileName { get; set; }

        public int UserSN { get; set; }

        #endregion private fields

        #region Constructor

        public ScenarioChar_Info()
        {
        }

        #endregion Constructor
    }

    public class ScenarioChar_Filter
    {
        //You can copy above ScenarioChar_Info field for search criteria
    }

    #endregion Implementation
}