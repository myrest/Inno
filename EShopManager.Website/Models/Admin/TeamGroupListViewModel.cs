using System;
using System.Runtime.Serialization;
using EShopManager.Core.Utility;
using System.Collections.Generic;
using EShopManager.Core.DB;

namespace EShopManager.Website.Models
{
    [DataContract]
    public class TeamGroupListViewModel : ResultBase
    {
        [DataMember(Name = "d")]
        public List<DbTeamGroupModel> DataResult { get; set; }
    }
}