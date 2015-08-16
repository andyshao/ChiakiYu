using System.Web.Mvc;
using ChiakiYu.Model.Settings;
using ChiakiYu.Service.Settings;
using ChiakiYu.Web.Areas.Admin.Controllers.Filters;

namespace ChiakiYu.Web.Areas.Admin.Controllers
{
    [ManageAuthorize(RequireSystemAdministrator = true)]
    public partial class AdminSettingController : Controller
    {

        #region 私有字段
        private readonly ISettingService<SiteSetting> _siteSettingService; 
        #endregion

        #region 构造函数
        public AdminSettingController(ISettingService<SiteSetting> siteSettingService)
        {
            _siteSettingService = siteSettingService;
        } 
        #endregion

        #region 站点设置

        /// <summary>
        ///     站点设置页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult SiteSettings()
        {
            var model = _siteSettingService.Get() ?? new SiteSetting();
            return View(model);
        }

        /// <summary>
        ///     站点设置提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult SiteSettings(SiteSetting model)
        {
            if (!ModelState.IsValid)
                return View(model);
            _siteSettingService.Save(model);
            return Json(new { MessageType = 1, MessageContent = "设置成功！" });
        } 

        #endregion
    }
}