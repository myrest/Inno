using InnoThink.Core.DB;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using InnoThink.Domain;
using Rest.Core.Utility;

namespace InnoThink.Website.Models
{
    [DataContract]
    public class TopicSimpleViewModel : ResultBase
    {
        private List<DbTopicViewModel> _DataResult { get; set; }

        [DataMember(Name = "d")]
        public List<DbTopicViewModel> DataResult
        {
            private set
            {
                value.ForEach(x =>
                {
                    x.GroupID = Encrypt.EncryptTeamGroupSN(x.TeamGroupSN);
                });

                _DataResult = value;
            }
            get
            {
                if (JoinedTopic != null && JoinedTopic.Count() > 0)
                {
                    _DataResult.ForEach(x =>
                    {
                        x.isJoined = JoinedTopic.Contains(x.TopicSN);
                    });
                }
                return _DataResult;
            }
        }

        public List<int> JoinedTopic { get; set; }

        //Store data get from database.
        private List<Topic_Info> _DBResult { get; set; }

        public List<Topic_Info> DBResult
        {
            get
            {
                return _DBResult;
            }
            set
            {
                _DBResult = value;

                _DataResult = value.Select(x => new DbTopicViewModel()
                {
                    isJoined = false,
                    DateClosed = x.DateClosed,
                    DateCreated = x.DateCreated,
                    LeaderLoginId = x.LeaderLoginId,
                    LogoImg = x.LogoImg,
                    PublishType = x.PublishType,
                    TopicSN = x.TopicSN,
                    Step = x.Step,
                    Subject = x.Subject,
                    Target = x.Target,
                    TeamGroupSN = x.TeamGroupSN,
                    TeamName = x.TeamName
                }).ToList();
            }
        }
    }

    [DataContract]
    public class DbTopicViewModel : Topic_Info
    {
        public bool isJoined { get; set; }
        public string GroupID { get; set; }
    }
}