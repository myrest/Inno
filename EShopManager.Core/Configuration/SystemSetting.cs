﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShopManager.Core.Configuration
{
    public class SystemSetting
    {
        public string StaticFileVersionNumber { get; set; }
        public string CDNServer { get; set; }
        public bool CaptchaCode { get; set; }
        public string FileUpLoadTempFolder { get; set; }
        public string FileUpLoadIcon { get; set; }
        public string FileUpLoadTeamLogo { get; set; }
        public string FileUpLoadBest { get; set; }
        public string FileUpLoadBestGAP { get; set; }
        public string FileUpLoadResult { get; set; }
        public string FileUpLoadScenario { get; set; }
    }
}
