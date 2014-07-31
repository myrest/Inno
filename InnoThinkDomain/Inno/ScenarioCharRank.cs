using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.ScenarioCharRank
{
    #region interface
    public interface IScenarioCharRank_Info
    {
        string LastUpdate { get; set; }
        int Rank { get; set; }
        int ScenarioCharSN { get; set; }
        int UserSN { get; set; }
    }
    #endregion

    #region Implementation
    [Rest.Core.PetaPoco.TableName("ScenarioCharRank")]
    [Rest.Core.PetaPoco.PrimaryKey("")]
    public class ScenarioCharRank_Info : IScenarioCharRank_Info
    {
        #region private fields
        public string LastUpdate { get; set; }
        public int Rank { get; set; }
        public int ScenarioCharSN { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public ScenarioCharRank_Info()
        {
        }
        #endregion
    }

    public class ScenarioCharRank_Filter
    {
        //You can copy above ScenarioCharRank_Info field for search criteria
    }
    #endregion
}
