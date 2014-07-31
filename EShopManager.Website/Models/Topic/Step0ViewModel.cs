using System;
using System.Runtime.Serialization;
using EShopManager.Core.Utility;
using System.Collections.Generic;
using EShopManager.Core.DB;
using EShopManager.Core.Model.Topic;

namespace EShopManager.Website.Models
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