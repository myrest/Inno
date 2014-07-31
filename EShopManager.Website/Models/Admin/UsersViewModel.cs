using System;
using System.Runtime.Serialization;
using EShopManager.Core.Utility;
using System.Collections.Generic;
using EShopManager.Core.DB;

namespace EShopManager.Website.Models
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