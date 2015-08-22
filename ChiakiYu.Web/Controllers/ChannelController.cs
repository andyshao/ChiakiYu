using System;
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
        ///     联系方式
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
        public virtual JsonResult Upload()
        {
            var nowTime = DateTime.Now;

            var savePath = string.Format("/Uploads/img/{0}/{1}/{2}/", nowTime.Year,
                nowTime.Month.ToString("D2"), nowTime.Day.ToString("D2")); //上传文件的路径 

            var localPath = Server.MapPath(savePath);
            if (!Directory.Exists(Path.GetDirectoryName(localPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(localPath));
            }
            var request = System.Web.HttpContext.Current.Request;
            var src = string.Empty;

            if (request.Files.Count <= 0) return Json(new {src, src1 = "111"});
            for (var i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];
                var extension = Path.GetExtension(file.FileName);
                var fileName = string.Format("{0}{1}",
                    DateTime.Now.ToString("HHmmss") + new Random().Next(100000, 999999), extension);
                file.SaveAs(localPath + fileName);
                src = savePath + fileName;
            }
            return Json(new {src, src1 = "111"});
        }
    }
}