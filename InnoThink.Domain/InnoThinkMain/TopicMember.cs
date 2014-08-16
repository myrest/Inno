using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain
{
    /*
    #region interface
    public interface ITopicMember_Info
    {
        string Description { get; set; }
        string HandleJob { get; set; }
        int LeaderSNVoteTo { get; set; }
        int TopicMemberSN { get; set; }
        int TopicSN { get; set; }
        int UsersSN { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("TopicMember")]
    [Rest.Core.PetaPoco.PrimaryKey("TopicMemberSN")]
    public class TopicMember_Info //: ITopicMember_Info
    {
        #region private fields
        public string Description { get; set; }
        public string HandleJob { get; set; }
        public int LeaderSNVoteTo { get; set; }
        public int TopicMemberSN { get; set; }
        public int TopicSN { get; set; }
        public int UsersSN { get; set; }
        #endregion

        #region Constructor
        public TopicMember_Info()
        {
        }
        #endregion
    }

    public class TopicMember_Filter
    {
        public string Description { get; set; }
        public string HandleJob { get; set; }
        public int? LeaderSNVoteTo { get; set; }
        public int? TopicMemberSN { get; set; }
        public int? TopicSN { get; set; }
        public int? UsersSN { get; set; }
        //You can copy/modify above TopicMember_Info field for search criteria
    }
    #endregion
}