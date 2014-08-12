using InnoThink.Core.DB;
using System.Collections.Generic;
using System.Runtime.Serialization;
using InnoThink.Domain;

namespace InnoThink.Website.Models
{
    [DataContract]
    public class UsersViewModel : ResultBase
    {
        [DataMember(Name = "d")]
        public List<User_Info> DataResult { get; set; }

        [DataMember(Name = "n")]
        public string TeamGroupName { get; set; }

        [DataMember(Name = "sn")]
        public int TeamGroupSN { get; set; }
    }
}