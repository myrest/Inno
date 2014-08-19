using CWB.Web.Configuration;
using InnoThink.Core.Cache.Board;
using InnoThink.Core.Configuration;
using Microsoft.AspNet.SignalR;
using Rest.Core.Utility;
using System;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InnoThink.Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801
    public class InnoThinkApplication : System.Web.HttpApplication
    {
        private static readonly SysLog Log = SysLog.GetLogger(typeof(InnoThinkApplication));
        private static readonly object syncRoot = new object();
        private string configurationFolder;
        public static bool isWatcherUpdate;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "BlankRoot", // Route name
                "", // URL with parameters
                new { controller = "Default", action = "Index" }// Parameter defaults
            );

            routes.MapRoute("image", // Route name
                      "image/{action}", // URL with parameters
                      new { controller = "ImageService", action = "Index" }// Parameter defaults

            );

            routes.MapRoute(
                "Admin", // Route name
                "Admin", // URL with parameters
                new { controller = "Default", action = "Admin", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Default", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            string configurationFolder = HttpContext.Current.Server.MapPath(string.Concat("\\Configuration\\"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configurationFolder + "Log4Net.config"));
            Log.Debug("Application_Start");

            var config = new HubConfiguration
            {
                EnableCrossDomain = true,
                EnableDetailedErrors = true
            };
            RouteTable.Routes.MapHubs(config);

            InitializeUiConfigurationManager(configurationFolder);

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //for watching updated config file.
            AddFileWatcher(configurationFolder, "watcher", () =>
            {
                if (isWatcherUpdate)
                {
                    InitializeUiConfigurationManager(configurationFolder);
                }
            });

            Log.Debug("Application_Start end");
        }

        public static void InitializeUiConfigurationManager(string configurationFolderPath)
        {
            InnoThinkApplication.isWatcherUpdate = false;
            lock (syncRoot)
            {
                AppConfigManager.SystemSetting = XmlSerializerHelper.ToObj<SystemSetting>(GetXml(configurationFolderPath, "SystemSetting.config"));
            }
        }

        private static string GetXml(string configurationFolderPath, string fileName)
        {
            return File.ReadAllText(configurationFolderPath + fileName);
        }

        //for watching updated file.
        private void AddFileWatcher(string configurationFolder, string watcherName, Action callBackMethod)
        {
            Application.Add(watcherName, new FileSystemWatcher(configurationFolder));
            FileSystemWatcher watcher = (FileSystemWatcher)Application[watcherName];
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            watcher.Changed += delegate
            {
                (new Thread(new ThreadStart(delegate
                {
                    watcher.ToString();
                    isWatcherUpdate = true;
                    Thread.Sleep(5000);
                    callBackMethod();
                }))).Start();
            };
        }
    }
}