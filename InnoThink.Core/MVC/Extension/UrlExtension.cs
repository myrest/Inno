using System;
using System.Web.Mvc;

namespace InnoThink.Core.MVC.Extensions
{
    public static class UrlExtension
    {
        private static readonly string VersionNumber = DateTime.Now.Second.ToString();

        public static string CdnContent(this UrlHelper url, string contentPath)
        {
            //return string.Concat(CdnManager.CDNServer + "CDN" + contentPath, "?v=", AppConfigManager.SystemSetting.StaticFileVersionNumber);
            return string.Concat("/CDN" + contentPath, "?v=", VersionNumber);
        }

        public static string CultureRoute(this UrlHelper url, string culture, string controllerName, string actionName)
        {
            return url.Action(actionName, controllerName, new { culture = culture });//(culture, new { controller = controllerName, action = actionName });
        }

        public static string CultureRoute(this UrlHelper url, string culture, string controllerName, string actionName, string id)
        {
            return url.Action(actionName, controllerName, new { culture = culture, id = id });//(culture, new { controller = controllerName, action = actionName });
        }
    }
}