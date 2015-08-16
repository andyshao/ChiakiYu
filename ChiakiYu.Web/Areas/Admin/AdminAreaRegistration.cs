using System.Configuration;
using System.Web.Mvc;

namespace ChiakiYu.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Admin"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            #region 对于IIS6.0默认配置不支持无扩展名的url

            var iisVersion = 0;
            if (!int.TryParse(ConfigurationManager.AppSettings.Get("IISVersion"), out iisVersion))
                iisVersion = 7;
            var extensionForOldIIS = iisVersion >= 7 ? string.Empty : ".aspx";

            #endregion

            #region Admin

            #region Admin

            context.MapRoute("Admin_Admin", "Admin/{action}" + extensionForOldIIS,
                new {controller = "Admin", action = "ManageLogin"}
                );

            #endregion

            #region Admin_User

            context.MapRoute("Admin_User_Common", "AdminUser/{action}" + extensionForOldIIS,
                new {controller = "AdminUser", action = "ManageUser"}
                );

            #endregion

            #region Admin_Setting

            context.MapRoute("Admin_Setting_Common", "AdminSetting/{action}" + extensionForOldIIS,
                new { controller = "AdminSetting", action = "SiteSettings" }
                );

            #endregion

            #endregion

            context.MapRoute("Admin_Common", "Admin/{action}/{id}",
                new {controller = "Admin", action = "Channel", id = UrlParameter.Optional}
                );
        }
    }
}