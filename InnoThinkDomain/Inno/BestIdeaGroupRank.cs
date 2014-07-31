using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.BestIdeaGroupRank
{
    #region interface
    public interface IBestIdeaGroupRank_Info
    {
        int BestIdeaGroupSN { get; set; }
        int Rank { get; set; }
        int UserSN { get; set; }
    }
    #endregion

    #region Implementation
    [Rest.Core.PetaPoco.TableName("BestIdeaGroupRank")]
    [Rest.Core.PetaPoco.PrimaryKey("")]
    public class BestIdeaGroupRank_Info : IBestIdeaGroupRank_Info
    {
        #region private fields
        public int BestIdeaGroupSN { get; set; }
        public int Rank { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public BestIdeaGroupRank_Info()
        {
        }
        #endregion
    }

    public class BestIdeaGroupRank_Filter
    {
        //You can copy above BestIdeaGroupRank_Info field for search criteria
    }
    #endregion
}
