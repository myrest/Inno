using InnoThink.Core.DB;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InnoThink.Website.Models
{
    [DataContract]
    public class TeamGroupListViewModel : ResultBase
    {
        [DataMember(Name = "d")]
        public List<DbTeamGroupModel> DataResult { get; set; }
    }
}