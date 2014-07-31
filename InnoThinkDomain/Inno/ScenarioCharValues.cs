using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.ScenarioCharValues
{
    #region interface
    public interface IScenarioCharValues_Info
    {
        string Description { get; set; }
        string LastUpdate { get; set; }
        int ScenarioCharSN { get; set; }
        int SN { get; set; }
        int UserSN { get; set; }
    }
    #endregion

    #region Implementation
    [Rest.Core.PetaPoco.TableName("ScenarioCharValues")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class ScenarioCharValues_Info : IScenarioCharValues_Info
    {
        #region private fields
        public string Description { get; set; }
        public string LastUpdate { get; set; }
        public int ScenarioCharSN { get; set; }
        public int SN { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public ScenarioCharValues_Info()
        {
        }
        #endregion
    }

    public class ScenarioCharValues_Filter
    {
        //You can copy above ScenarioCharValues_Info field for search criteria
    }
    #endregion
}
