using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.ScenarioCharValuesRank
{
    #region interface
    public interface IScenarioCharValuesRank_Info
    {
        string LastUpdate { get; set; }
        int Rank { get; set; }
        int ScenarioCharValueSN { get; set; }
        int UserSN { get; set; }
    }
    #endregion

    #region Implementation
    [Rest.Core.PetaPoco.TableName("ScenarioCharValuesRank")]
    [Rest.Core.PetaPoco.PrimaryKey("")]
    public class ScenarioCharValuesRank_Info : IScenarioCharValuesRank_Info
    {
        #region private fields
        public string LastUpdate { get; set; }
        public int Rank { get; set; }
        public int ScenarioCharValueSN { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public ScenarioCharValuesRank_Info()
        {
        }
        #endregion
    }

    public class ScenarioCharValuesRank_Filter
    {
        //You can copy above ScenarioCharValuesRank_Info field for search criteria
    }
    #endregion
}
