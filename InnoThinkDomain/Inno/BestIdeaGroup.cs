namespace InnoThink.Domain.BestIdeaGroup
{
    #region interface

    public interface IBestIdeaGroup_Info
    {
        string BestIdeaSNs { get; set; }

        string GroupName { get; set; }

        string Rank { get; set; }

        int SN { get; set; }

        string TopicSN { get; set; }

        string Type { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("BestIdeaGroup")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class BestIdeaGroup_Info : IBestIdeaGroup_Info
    {
        #region private fields

        public string BestIdeaSNs { get; set; }

        public string GroupName { get; set; }

        public string Rank { get; set; }

        public int SN { get; set; }

        public string TopicSN { get; set; }

        public string Type { get; set; }

        #endregion private fields

        #region Constructor

        public BestIdeaGroup_Info()
        {
        }

        #endregion Constructor
    }

    public class BestIdeaGroup_Filter
    {
        //You can copy above BestIdeaGroup_Info field for search criteria
    }

    #endregion Implementation
}