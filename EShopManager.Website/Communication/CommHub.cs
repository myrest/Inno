using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Web;
using EShopManager.Core.Cache.SignalR;

namespace EShopManager.Website.Communication
{
    [HubName("innoComm")]
    public class CommHub : Hub
    {
        private readonly CommServer commServer;

        public CommHub() : this(CommServer.Instance) { }
        public CommHub(CommServer obj)
        {
            commServer = obj;
        }


        #region Connect, Disconnect and Reconnect event.
        //Client connect event.
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        //Client disconnect event.
        public override Task OnDisconnected()
        {
            //remove from all the cache
            var obj = ConnectionManageBase.GetByUserConnectionId(Context.ConnectionId);
            if (obj != null)
            {
                var newobj = ConnectionManageBase.GetByUserSN(obj.UserSN);
                //only user left the topic will trigger off line event.
                if (newobj == null || obj.TopicSN != newobj.TopicSN)
                {
                    commServer.syncOfflineUser(obj.TopicSN, obj.UserSN);
                }
            }
            Unit1Cache.Remove(Context.ConnectionId);
            return base.OnDisconnected();
        }

        //Client disconnect event.
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
        #endregion

        public void init()
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["ConnectionId"] = Context.ConnectionId;
            }
            commServer.init(Context);
        }

        //第1單元介紹：認識朋友-1
        public void initUnit1(int sn)
        {
            commServer.initUnit1(Context, sn);
        }

        //同步各個Client端資料
        public void syncUIInfo(int TopicSN, string ElementName, string ElementValue, string AttName, string AttValue)
        {
            commServer.syncUIInfo(TopicSN, ElementName, ElementValue, AttName, AttValue);
        }
    }
}