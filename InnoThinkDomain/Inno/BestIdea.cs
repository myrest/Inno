namespace InnoThink.Domain.BestIdea
{
    #region interface

    public interface IBestIdea_Info
    {
        string Description { get; set; }

        string Idea { get; set; }

        string LastUpdate { get; set; }

        int Ranking { get; set; }

        int SN { get; set; }

        int TopicSN { get; set; }

        int Type { get; set; }

        int UserSN { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("BestIdea")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class BestIdea_Info : IBestIdea_Info
    {
        #region private fields

        public string Description { get; set; }

        public string Idea { get; set; }

        public string LastUpdate { get; set; }

        public int Ranking { get; set; }

        public int SN { get; set; }

        public int TopicSN { get; set; }

        public int Type { get; set; }

        public int UserSN { get; set; }

        #endregion private fields

        #region Constructor

        public BestIdea_Info()
        {
        }

        #endregion Constructor
    }

    public class BestIdea_Filter
    {
        //You can copy above BestIdea_Info field for search criteria
    }

    #endregion Implementation
}