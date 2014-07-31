using System;
using System.Linq;
using System.Runtime.Serialization;
using EShopManager.Core.Utility;
using System.Collections.Generic;
using EShopManager.Core.DB;

namespace EShopManager.Website.Models
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
                _DataResult = value;
            }
            get
            {
                if (JoinedTopic != null && JoinedTopic.Count() > 0)
                {
                    _DataResult.ForEach(x =>
                    {
                        x.isJoined = JoinedTopic.Contains(x.SN);
                    });
                }
                return _DataResult;
            }
        }

        public List<int> JoinedTopic { get; set; }

        //Store data get from database.
        private List<DbTopicModel> _DBResult { get; set; }
        public List<DbTopicModel> DBResult
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
                    CreatedLoginId = x.CreatedLoginId,
                    DateClosed = x.DateClosed,
                    DateCreated = x.DateCreated,
                    LeaderLoginId = x.LeaderLoginId,
                    LogoImg = x.LogoImg,
                    PublishType = x.PublishType,
                    SN = x.SN,
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
    public class DbTopicViewModel : DbTopicModel
    {
        public bool isJoined { get; set; }
    }
}