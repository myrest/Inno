﻿using InnoThink.Core.DB;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace InnoThink.Website.Models
{
    [DataContract]
    public class ScenarioCharViewModel : ResultBase
    {
        private int _UserSN { get; set; }

        public ScenarioCharViewModel(int UserSN)
        {
            _UserSN = UserSN;
        }

        public int TopicSN { get; set; }

        [DataMember(Name = "d")]
        public List<DbScenarioCharModel> Listing { get; set; }

        public DbScenarioCharModel Data
        {
            get
            {
                DbScenarioCharModel rtn = new DbScenarioCharModel() { };
                if (Listing != null && Listing.Count() > 0)
                {
                    rtn = Listing.Where(x => x.UserSN == _UserSN).FirstOrDefault();
                    if (rtn == null)
                    {
                        rtn = new DbScenarioCharModel() { };
                    }
                }
                return rtn;
            }
        }
    }
}