using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.BestGAP
{
    #region interface
    public interface IBestGAP_Info
    {
        string BestIdeaGroupSNs { get; set; }
        string Description { get; set; }
        string Document { get; set; }
        int LastUpdate { get; set; }
        string MyGAP { get; set; }
        int SN { get; set; }
        int TopicSN { get; set; }
        int UserSN { get; set; }
    }
    #endregion

    #region Implementation
    [Rest.Core.PetaPoco.TableName("BestGAP")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class BestGAP_Info : IBestGAP_Info
    {
        #region private fields
        public string BestIdeaGroupSNs { get; set; }
        public string Description { get; set; }
        public string Document { get; set; }
        public int LastUpdate { get; set; }
        public string MyGAP { get; set; }
        public int SN { get; set; }
        public int TopicSN { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public BestGAP_Info()
        {
        }
        #endregion
    }

    public class BestGAP_Filter
    {
        //You can copy above BestGAP_Info field for search criteria
    }
    #endregion
}
