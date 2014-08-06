using System;
using System.Runtime.Serialization;
using InnoThink.Core.Utility;
using System.Collections.Generic;
using InnoThink.Core.DB;

namespace InnoThink.Website.Models
{
    [DataContract]
    public class UsersViewModel : ResultBase
    {
        [DataMember(Name = "d")]
        public List<DbUserModel> DataResult { get; set; }

        [DataMember(Name = "n")]
        public string TeamGroupName { get; set; }

        [DataMember(Name = "sn")]
        public int TeamGroupSN { get; set; }
    }
}