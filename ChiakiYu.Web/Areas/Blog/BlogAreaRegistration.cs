using System.Configuration;
using System.Web.Mvc;

namespace ChiakiYu.Web.Areas.Blog
{
    public class BlogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Blog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            #region 对于IIS6.0默认配置不支持无扩展名的url

            var iisVersion = 0;
            if (!int.TryParse(ConfigurationManager.AppSettings.Get("IISVersion"), out iisVersion))
                iisVersion = 7;
            var extensionForOldIIS = iisVersion >= 7 ? string.Empty : ".aspx";

            #endregion


            context.MapRoute(
                "Blog_Home",
                "Blog" + extensionForOldIIS,
                new { controller = "Blog", action = "Home" }
                );

            context.MapRoute(
                "Blog_Common",
                "Blog/{action}/{id}",
                new { controller = "Blog", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}