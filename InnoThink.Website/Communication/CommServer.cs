using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using InnoThink.Core.Utility;
using InnoThink.Core.Cache.SignalR;
using InnoThink.Core.Model.Topic;
using InnoThink.Core.DB;
using InnoThink.Core.MVC;
using InnoThink.Core;
using InnoThink.Core.Constancy;
using InnoThink.Website.Models;
using Rest.Core.Utility;

namespace InnoThink.Website.Communication
{
    public class CommServer
    {
        // Singleton instance
        private static readonly SysLog Log = SysLog.GetLogger(typeof(CommServer));
        private readonly static Lazy<CommServer> _Instance = new Lazy<CommServer>(() => new CommServer(GlobalHost.ConnectionManager.GetHubContext<CommHub>().Clients));
        public delegate void Broadcast(string SystemMessage);

        private IHubConnectionContext Clients { get; set; }
        public CommServer(IHubConnectionContext clients)
        {
            this.Clients = clients;
        }

        public static CommServer Instance
        {
            get
            {
                return _Instance.Value;
            }
        }

        private void KickOffUser(string connectionId, string msg)
        {
            Clients.Client(connectionId).KickOut(msg);
        }

        private void DeliveryMsg(string msg)
        {
            Clients.All.serverMessage(msg);
        }

        internal void JumpToStep(int TopicSN, string url)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).JumpToStep(url);
            });
        }

        //第1單元介紹：認識朋友-1 update
        /// <summary>
        ///  同步更新資料
        /// </summary>
        /// <param name="sn">議題流水號</param>
        /// <param name="msg">更新的內容</param>
        internal void Unit1update(int TopicSN, SignalRMessageUnitModel msg)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).Unit1(msg);
            });
        }

        internal void init(HubCallerContext Context)
        {
            //put initial action in here
        }


        //第1單元介紹：認識朋友-1 initial
        internal void initUnit1(HubCallerContext Context, int sn)
        {
            //Add connection control.
            SessionData sessionData = new SessionData();
            Unit1Cache.Add(sn, Context.ConnectionId);
            Clients.Client(Context.ConnectionId).ServerInitCache(Context.ConnectionId);
        }

        internal void syncUIInfo(int TopicSN, string ElementName, string ElementValue, string AttName, string AttValue)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).SyncUIInfo(ElementName, ElementValue, AttName, AttValue);
            });
        }

        internal void syncUIBoardMessage(DbBoardContent model)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(model.TopicSN);
            list.ForEach(x =>
            {
                if (model.PublishType == 0)
                {
                    Clients.Client(x).syncUIPrivateMessage(model);
                }
                else
                {
                    Clients.Client(x).syncUIPublicMessage(model);
                }
            });
        }

        internal void syncStep1(DbTopicModel topic, IEnumerable<KeyValuePair<string, string>> users)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(topic.SN);
            list.ForEach(x =>
            {
                Clients.Client(x).syncUIStep1(topic, users);
            });
        }

        internal void syncUIResult(DbResultsModel model, ResultType Result)
        {
            model.Column1 = StringUtility.ConvertNewLineToBR(model.Column1);
            model.Column2 = StringUtility.ConvertNewLineToBR(model.Column2);
            model.Column3 = StringUtility.ConvertNewLineToBR(model.Column3);
            model.Column4 = StringUtility.ConvertNewLineToBR(model.Column4);

            //get connections
            var list = Unit1Cache.GetAllConnections(model.TopicSN);
            switch (Result)
            {
                case ResultType.DRAFT:
                    list.ForEach(x =>
                    {
                        Clients.Client(x).syncResultDraft(model);
                    });
                    break;
                case ResultType.DASHBOARD:
                    list.ForEach(x =>
                    {
                        Clients.Client(x).syncResultDashboard(model);
                    });
                    break;
                case ResultType.PRESENTATION:
                    list.ForEach(x =>
                    {
                        Clients.Client(x).syncResultPresentation(model);
                    });
                    break;
                case ResultType.SCENARIO_1:
                    list.ForEach(x =>
                    {
                        Clients.Client(x).syncScenario1(model);
                    });
                    break;
                case ResultType.SCENARIO_3:
                    //just using the same parse rule for UI display information.
                    ScenarioCharResultViewModel result3 = new ScenarioCharResultViewModel(0) { };
                    result3.Descriptions = new List<DbResultsModel>() { };
                    result3.Descriptions.Add(model);
                    list.ForEach(x =>
                    {
                        Clients.Client(x).syncScenario3(result3.AllDescript);
                    });
                    break;
                case ResultType.SCENARIO_7:
                    //just using the same parse rule for UI display information.
                    ScenarioCharResultViewModel result7 = new ScenarioCharResultViewModel(0) { };
                    result7.Descriptions = new List<DbResultsModel>() { };
                    result7.Descriptions.Add(model);
                    list.ForEach(x =>
                    {
                        Clients.Client(x).syncScenario7(result7.AllDescript);
                    });
                    break;
                default:
                    throw new Exception("Type not in defined");
            }

        }

        internal void syncUIResultScore(DbResultsScoreModel model)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(model.TopicSN);
            switch (model.Result)
            {
                case ResultType.DRAFT:
                    list.ForEach(x =>
                    {
                        Clients.Client(x).syncRSDraft(model);
                    });
                    break;
                case ResultType.DASHBOARD:
                    list.ForEach(x =>
                    {
                        Clients.Client(x).syncRSDashboard(model);
                    });
                    break;
                case ResultType.PRESENTATION:
                    list.ForEach(x =>
                    {
                        Clients.Client(x).syncRSPresentation(model);
                    });
                    break;
                default:
                    throw new Exception("");
            }

        }

        internal void syncUIBest1(DbBestStep1Model model)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(model.TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).syncBest1(model);
            });
        }

        internal void syncUIBestIdea(DbBestIdeaModel model)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(model.TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).syncBestIdea(model);
            });
        }

        internal void syncUIBestIdeaGroup(DbBestIdeaGroup model)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(model.TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).syncBestIdeaGroup(model);
            });
        }

        internal void syncUIBestIGAP(DbBestGAPModel model)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(model.TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).syncBestGAP(model);
            });
        }

        internal void syncOnlineUser(int TopicSN, DbUserModel user)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).syncOnlineUser(user);
            });
        }

        internal void syncOfflineUser(int TopicSN, int UserSN)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).syncOfflineUser(UserSN);
            });
        }

        internal void syncUIScenario2(DbScenarioCharModel model)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(model.TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).syncUIScenario2(model);
            });
        }

        internal void syncUIScenario4(int TopicSN, DbScenarioCharValueModel model)
        {
            //get connections
            var list = Unit1Cache.GetAllConnections(TopicSN);
            list.ForEach(x =>
            {
                Clients.Client(x).syncScenario4(model);
            });
        }
    }
}