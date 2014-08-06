using System;
using System.Runtime.Serialization;
using InnoThink.Core.Utility;
using System.Collections.Generic;
using InnoThink.Core.DB;
using InnoThink.Core.Model.Topic;

namespace InnoThink.Website.Models
{
    public class Step1ViewModel
    {
        public int TopicSN { get; set; }
        public Dictionary<int, TeamMemberUIModel> TeamMembers { get; set; }

        public string LeaderName { get; set; }
        public int LeaderUserSN { get; set; }
        public bool IsLeader { get; set; }

        public string TeamName { get; set; }
        public string Subject { get; set; }
        public string Target { get; set; }
        public string LogoImage { get; set; }
        public string DateCreated { get; set; }
    }
}