using InnoThink.Core.Constancy;
using System;
using System.Web;
using InnoThink.Domain.Constancy;

namespace InnoThink.Core
{
    public class SessionData
    {
        public static readonly string TradingSessionKey = SessionKeys.Trading.ToString();

        public Trading trading
        {
            get
            {
                return (Trading)HttpContext.Current.Session[TradingSessionKey];
            }
            set
            {
                HttpContext.Current.Session[TradingSessionKey] = value;
            }
        }

        public void ClearTempValue()
        {
            this.trading._tempFileName = string.Empty;
            this.trading._OrignFileName = string.Empty;
            this.trading._tempInt = 0;
        }

        public void Logout()
        {
            Trading ordTrading = (Trading)HttpContext.Current.Session[TradingSessionKey];
            Trading newTrading = new Trading();
            this.trading = newTrading;
        }

        public void ClearALL()
        {
            this.trading = null;
            HttpContext.Current.Session.Clear();
        }
    }

    [Serializable]
    public class Trading
    {
        public Trading()
        {
            LoginId = default(string);
            isLogined = false;
            UserSN = 0;
            Level = 0;
            FBAccessToken = string.Empty;
        }

        public string LoginId { get; set; }

        public bool isLogined { get; set; }

        public int Level { get; set; }

        public int UserSN { get; set; }

        public string FBAccessToken { get; set; }
        
        public string Picture { get; set; }

        public string UserName { get; set; }

        public string _tempFileName { get; set; }

        public string _OrignFileName { get; set; }

        public bool _isImage { get; set; }

        private int __tempInt;

        /// <summary>
        /// Set the temp Int value, when set this value will clear "_tempFileName" at the same time.
        /// </summary>
        public int _tempInt
        {
            get
            {
                return __tempInt;
            }
            set
            {
                __tempInt = value;
                _tempFileName = string.Empty;
                _OrignFileName = string.Empty;
                _isImage = false;
            }
        }
    }
}