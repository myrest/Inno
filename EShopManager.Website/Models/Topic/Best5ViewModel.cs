using System;
using System.Runtime.Serialization;
using EShopManager.Core.Utility;
using System.Collections.Generic;
using EShopManager.Core.DB;
using EShopManager.Core.Model.Topic;

namespace EShopManager.Website.Models
{
    public class Best5ViewModel : ResultBase
    {
        public int TopicSN { get; set; }
        public List<DbBestIdeaGroupRankModel> Listing { get; set; }
    }
}