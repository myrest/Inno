using System;
using System.Runtime.Serialization;
using InnoThink.Core.Utility;
using System.Collections.Generic;
using InnoThink.Core.DB;

namespace InnoThink.Website.Models
{
    [DataContract]
    public class TeamGroupListViewModel : ResultBase
    {
        [DataMember(Name = "d")]
        public List<DbTeamGroupModel> DataResult { get; set; }
    }
}