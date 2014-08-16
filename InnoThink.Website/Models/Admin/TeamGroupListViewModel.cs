using InnoThink.Core.DB;
using System.Collections.Generic;
using System.Runtime.Serialization;
using InnoThink.Domain;

namespace InnoThink.Website.Models
{
    [DataContract]
    public class TeamGroupListViewModel : ResultBase
    {
        [DataMember(Name = "d")]
        public List<TeamGroup_Info> DataResult { get; set; }
    }
}