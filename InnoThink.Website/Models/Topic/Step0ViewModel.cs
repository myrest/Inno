using InnoThink.Core.Model.Topic;
using System.Collections.Generic;
using InnoThink.Domain.InnoThinkMain.Binding;

namespace InnoThink.Website.Models
{
    public class Step0ViewModel
    {
        public string MyDescription { get; set; }

        public int TopicSN { get; set; }

        public Dictionary<int, TopicMemberUI> TeamMembers { get; set; }

        public int LeaderVoteTo { get; set; }

        public string Leader { get; set; }
    }
}