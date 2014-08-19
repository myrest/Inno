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
        public List<TeamGroupUI> DataResult { get; set; }
    }

    [DataContract]
    public class TeamGroupUI : TeamGroup_Info
    {
        [DataMember(Name = "tid")]
        public string TeamGroupID { get; set; }
    }
}