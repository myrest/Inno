using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShopManager.Core.Cache.SignalR
{
    public class ConnectionManageBase
    {
        //private static Dictionary<int, List<ConnectionObject>> AllConnections = new Dictionary<int, List<ConnectionObject>>() { };
        private static List<ConnectionObject> AllConnections = new List<ConnectionObject>() { };

        public static List<string> GetAllConnections(int TopicSN)
        {
            var TopicConnObj = AllConnections.Where(x => x.TopicSN == TopicSN).ToList();
            if (TopicConnObj == null)
            {
                return new List<string>() { };
            }
            else
            {
                return TopicConnObj.Select(x => x.ConnectionID).ToList();
            }
        }

        public static List<int> GetAllOnLineUserSN(int TopicSN)
        {
            var TopicConnObj = AllConnections.Where(x => x.TopicSN == TopicSN).ToList();
            if (TopicConnObj == null)
            {
                return new List<int>() { };
            }
            else
            {
                return TopicConnObj.Select(x => x.UserSN).ToList();
            }
        }

        public static void Add(int TopicSN, string ConnectionId)
        {
            //check the connectionnid is exist?
            var CacheObj = AllConnections.Where(x => x.ConnectionID == ConnectionId).FirstOrDefault();
            if (CacheObj != null)
            {
                //this block should not be trigger, because any new connection will has different connection id.

                //update current topic sn.
                CacheObj.TopicSN = TopicSN;
                //Same User sn only can apply to one connection id.
                //Need remove other connection.
                AllConnections.Remove(AllConnections.Find(x=>x.UserSN == CacheObj.UserSN && x.ConnectionID != ConnectionId));
            }
            else
            {
                AllConnections.Add(new ConnectionObject()
                {
                    ConnectionID = ConnectionId,
                    TopicSN = TopicSN
                });
            }

        }

        public static void Update(string ConnectionId, int UserSN)
        {
            //check the connectionnid is exist?
            var CacheObj = AllConnections.Where(x => x.ConnectionID == ConnectionId).FirstOrDefault();
            if (CacheObj != null)
            {
                //update current User SN
                CacheObj.UserSN = UserSN;
            }
        }

        public static void Remove(string ConnectionId)
        {
            if (AllConnections.Count() > 0)
            {
                var cid = AllConnections.Find(x => x.ConnectionID == ConnectionId);
                if (cid != null)
                {
                    AllConnections.Remove(cid);
                }
            }
        }

        public static ConnectionObject GetByUserSN(int UserSN)
        {
            return AllConnections.Where(x => x.UserSN == UserSN).FirstOrDefault();
        }

        public static ConnectionObject GetByUserConnectionId(string ConnectionID)
        {
            return AllConnections.Where(x => x.ConnectionID == ConnectionID).FirstOrDefault();
        }
    }

    public class ConnectionObject
    {
        public int TopicSN { get; set; }
        public string ConnectionID { get; set; }
        public int UserSN { get; set; }
    }

}
