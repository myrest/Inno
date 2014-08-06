using System;
using System.Runtime.Serialization;
using InnoThink.Core.Utility;
using System.Collections.Generic;
using InnoThink.Core.DB;
using InnoThink.Core.Model.Topic;

namespace InnoThink.Website.Models
{
    public class Step0ViewModel
    {
        public string MyDescription { get; set; }
        public int TopicSN { get; set; }
        public Dictionary<int, TeamMemberUIModel> TeamMembers { get; set; }
        public int LeaderVoteTo { get; set; }
        public string Leader { get; set; }
    }
}