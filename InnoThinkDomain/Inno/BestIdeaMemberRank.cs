using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.BestIdeaMemberRank
{
    #region interface
    public interface IBestIdeaMemberRank_Info
    {
        int BestIdeaSN { get; set; }
        int Rank { get; set; }
        int UserSN { get; set; }
    }
    #endregion

    #region Implementation
    [Rest.Core.PetaPoco.TableName("BestIdeaMemberRank")]
    [Rest.Core.PetaPoco.PrimaryKey("")]
    public class BestIdeaMemberRank_Info : IBestIdeaMemberRank_Info
    {
        #region private fields
        public int BestIdeaSN { get; set; }
        public int Rank { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public BestIdeaMemberRank_Info()
        {
        }
        #endregion
    }

    public class BestIdeaMemberRank_Filter
    {
        //You can copy above BestIdeaMemberRank_Info field for search criteria
    }
    #endregion
}
