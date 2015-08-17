using System.IO;
using System.Web.Mvc;
using ChiakiYu.Model.Navigations;
using ChiakiYu.Service.Navigations;

namespace ChiakiYu.Web.Controllers
{
    public partial class ChannelController : Controller
    {
        #region 私有字段
        private readonly INavigationService _navigationService;
        #endregion

        #region 构造函数

        public ChannelController(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion


        /// <summary>
        ///     页头
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public virtual ActionResult _Header(string activeMenu = "")
        {

            var list = _navigationService.GetNavigations(PresentArea.Channel);
            ViewData["Active"] = activeMenu;
            return PartialView(list);
        }

        /// <summary>
        ///     首页
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Home()
        {
            return View();
        }

        /// <summary>
        ///     关于我们
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// 联系方式
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult ContactUs()
        {
            return View();
        }

        public virtual ActionResult Chat()
        {
            return View();
        }

        public virtual ActionResult ComingSoon()
        {
            return View();
        }

        [HttpPost]
        public virtual ContentResult Upload()
        {
            string savePath; //上传文件的路径 
            savePath = "\\Uploads\\";

            var localPath = Server.MapPath(savePath);
            if (!Directory.Exists(Path.GetDirectoryName(localPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(localPath));
            }
            var request = System.Web.HttpContext.Current.Request;
            var src = string.Empty;

            if (request.Files.Count <= 0) return Content(src);
            for (var i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];
                var fileName = file.FileName;
                file.SaveAs(localPath + fileName);
                src = "http://" + request.Url.Host + request.ApplicationPath + "/Uploads/" + fileName;
            }
            return Content(src);
        }
    }

}