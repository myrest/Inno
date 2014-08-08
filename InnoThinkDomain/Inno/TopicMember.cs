namespace InnoThink.Domain.TopicMember
{
    #region interface

    public interface ITopicMember_Info
    {
        string Description { get; set; }

        string HandleJob { get; set; }

        int LeaderSNVoteTo { get; set; }

        int SN { get; set; }

        int TopicSN { get; set; }

        int UsersSN { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("TopicMember")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class TopicMember_Info : ITopicMember_Info
    {
        #region private fields

        public string Description { get; set; }

        public string HandleJob { get; set; }

        public int LeaderSNVoteTo { get; set; }

        public int SN { get; set; }

        public int TopicSN { get; set; }

        public int UsersSN { get; set; }

        #endregion private fields

        #region Constructor

        public TopicMember_Info()
        {
        }

        #endregion Constructor
    }

    public class TopicMember_Filter
    {
        //You can copy above TopicMember_Info field for search criteria
    }

    #endregion Implementation
}