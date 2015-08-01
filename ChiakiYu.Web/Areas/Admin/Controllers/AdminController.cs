using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ChiakiYu.Common.Data;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Navigations;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Navigations;
using ChiakiYu.Service.Users;
using ChiakiYu.Web.Areas.Admin.Controllers.Filters;
using ChiakiYu.Web.ViewModels.Account;

namespace ChiakiYu.Web.Areas.Admin.Controllers
{
    public partial class AdminController : Controller
    {
        #region 构造函数

        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;

        private readonly IRepository<User, long> _repository;

        public AdminController(INavigationService navigationService, IUserService userService,
            IRepository<User, long> repository)
        {
            _navigationService = navigationService;
            _userService = userService;
            _repository = repository;
        }

        #endregion

        #region 主页&页头

        /// <summary>
        ///     后台主页
        /// </summary>
        /// <returns></returns>
        [ManageAuthorize(RequireSystemAdministrator = true)]
        public virtual ActionResult Home()
        {
            return View();
        }

        /// <summary>
        ///     页头
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public virtual ActionResult _Navigation(string activeMenu = "")
        {
            var list = _navigationService.GetNavigations(PresentArea.Admin);
            ViewData["Active"] = activeMenu;
            return PartialView(list);
        }

        #endregion

        #region 登录&注销

        /// <summary>
        ///     登录的页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult ManageLogin()
        {
            var users = _repository.GetAll().ToList();
            var userss = _userService.GetAll().ToList();
            return View();
        }

        /// <summary>
        ///     后台登录验证
        /// </summary>
        [HttpPost]
        public virtual ActionResult ManageLogin(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = model.AsUser();
            var userLoginStatus = _userService.ValidateUser(user.UserName, user.Password);
            switch (userLoginStatus)
            {
                case UserLoginStatus.Success:
                    user = _userService.GetAll().FirstOrDefault(n => n.UserName == user.UserName);
                    break;
                case UserLoginStatus.IsNotExist:
                    TempData["StatusMessageData"] = "账号不存在！";

                    break;
                case UserLoginStatus.InvalidCredentials:
                    TempData["StatusMessageData"] = "帐号或密码错误，请重新输入！";

                    break;
                case UserLoginStatus.NotActivated:
                    TempData["StatusMessageData"] = "账号未激活！";

                    break;
                case UserLoginStatus.Banned:
                    TempData["StatusMessageData"] = "账号被封禁！";

                    break;
                case UserLoginStatus.UnknownError:
                    TempData["StatusMessageData"] = "未知错误，请重试！";
                    break;
                default:
                    TempData["StatusMessageData"] = "未知错误，请重试！";

                    break;
            }

            if (userLoginStatus != UserLoginStatus.Success) return View(model);
            FormsAuthentication.SignOut();

            var adminCookie = new HttpCookie("ChiakiAdminCookie" + user.Id)
            {
                Value = UserPasswordHelper.MD5(true.ToString())
            };
            if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
                adminCookie.Domain = FormsAuthentication.CookieDomain;
            adminCookie.HttpOnly = true;

            Response.Cookies.Add(adminCookie);
            FormsAuthentication.SetAuthCookie(user.UserName, model.RememberMe);

            if (string.IsNullOrWhiteSpace(model.ReturnUrl))
            {
                return RedirectToAction(MVC.Admin.Admin.Home());
            }
            return Redirect(model.ReturnUrl);
        }

        /// <summary>
        ///     注销登录
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            //AuthenticationManager.SignOut();
            return RedirectToAction(MVC.Admin.Admin.ManageLogin());
        }

        #endregion
    }
}