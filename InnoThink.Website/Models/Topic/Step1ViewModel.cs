using InnoThink.Core.Model.Topic;
using System.Collections.Generic;
using InnoThink.Domain.InnoThinkMain.Binding;

namespace InnoThink.Website.Models
{
    public class Step1ViewModel
    {
        public int TopicSN { get; set; }

        public Dictionary<int, TopicMemberUI> TeamMembers { get; set; }

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