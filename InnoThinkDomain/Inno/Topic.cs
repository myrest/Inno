using System;

namespace InnoThink.Domain.Topic
{
    #region interface

    public interface ITopic_Info
    {
        string CreatedLoginId { get; set; }

        DateTime DateClosed { get; set; }

        DateTime DateCreated { get; set; }

        string LeaderLoginId { get; set; }

        string LogoImg { get; set; }

        int PublishType { get; set; }

        int SN { get; set; }

        int Step { get; set; }

        string Subject { get; set; }

        string Target { get; set; }

        int TeamGroupSN { get; set; }

        string TeamName { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("Topic")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class Topic_Info : ITopic_Info
    {
        #region private fields

        public string CreatedLoginId { get; set; }

        public DateTime DateClosed { get; set; }

        public DateTime DateCreated { get; set; }

        public string LeaderLoginId { get; set; }

        public string LogoImg { get; set; }

        public int PublishType { get; set; }

        public int SN { get; set; }

        public int Step { get; set; }

        public string Subject { get; set; }

        public string Target { get; set; }

        public int TeamGroupSN { get; set; }

        public string TeamName { get; set; }

        #endregion private fields

        #region Constructor

        public Topic_Info()
        {
        }

        #endregion Constructor
    }

    public class Topic_Filter
    {
        //You can copy above Topic_Info field for search criteria
    }

    #endregion Implementation
}