using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChiakiYu.Web
{
    public class RouteConfig
    {
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            #region 对于IIS6.0默认配置不支持无扩展名的url

            var iisVersion = 0;
            if (!int.TryParse(ConfigurationManager.AppSettings.Get("IISVersion"), out iisVersion))
                iisVersion = 7;
            var extensionForOldIIS = iisVersion >= 7 ? string.Empty : ".aspx";

            #endregion

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Channel_SiteHome", // Route name
                "", // URL with parameters
                new { controller = "Channel", action = "Home" } // Parameter defaults
                );

            routes.MapRoute(
                "Channel_Home", // Route name
                "Home" + extensionForOldIIS, // URL with parameters
                new { controller = "Channel", action = "Home" } // Parameter defaults
                );

            #region Channel

            routes.MapRoute(
                "Channel_About", // Route name
                "About" + extensionForOldIIS, // URL with parameters
                new { controller = "Channel", action = "About" } // Parameter defaults
                );

            routes.MapRoute(
                "Channel_ContactUs", // Route name
                "ContactUs" + extensionForOldIIS, // URL with parameters
                new { controller = "Channel", action = "ContactUs" } // Parameter defaults
                );

            routes.MapRoute(
                "Channel_Chat", // Route name
                "Chat" + extensionForOldIIS, // URL with parameters
                new { controller = "Channel", action = "Chat" } // Parameter defaults
                );

            routes.MapRoute(
                "Channel_ComingSoon", // Route name
                "ComingSoon" + extensionForOldIIS, // URL with parameters
                new { controller = "Channel", action = "ComingSoon" } // Parameter defaults
                );

            #endregion

            #region Account

            routes.MapRoute(
                "Account_Common", 
                "Account/{action}" + extensionForOldIIS,
                new { controller = "Account", action = "Login" }
                );

            #endregion

            


            routes.MapRoute(
                "Common", 
                "{controller}/{action}/{id}",
                new { controller = "Channel", action = "Channel", id = UrlParameter.Optional }
                );
        }
    }
}