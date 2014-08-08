namespace InnoThink.Domain.BestIdeaMemberRank
{
    #region interface

    public interface IBestIdeaMemberRank_Info
    {
        int BestIdeaSN { get; set; }

        int Rank { get; set; }

        int UserSN { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("BestIdeaMemberRank")]
    [Rest.Core.PetaPoco.PrimaryKey("")]
    public class BestIdeaMemberRank_Info : IBestIdeaMemberRank_Info
    {
        #region private fields

        public int BestIdeaSN { get; set; }

        public int Rank { get; set; }

        public int UserSN { get; set; }

        #endregion private fields

        #region Constructor

        public BestIdeaMemberRank_Info()
        {
        }

        #endregion Constructor
    }

    public class BestIdeaMemberRank_Filter
    {
        //You can copy above BestIdeaMemberRank_Info field for search criteria
    }

    #endregion Implementation
}