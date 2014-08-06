﻿using System;
using System.Runtime.Serialization;
using InnoThink.Core.Utility;
using System.Collections.Generic;
using InnoThink.Core.DB;
using InnoThink.Core.Model.Topic;

namespace InnoThink.Website.Models
{
    public class Best5ViewModel : ResultBase
    {
        public int TopicSN { get; set; }
        public List<DbBestIdeaGroupRankModel> Listing { get; set; }
    }
}