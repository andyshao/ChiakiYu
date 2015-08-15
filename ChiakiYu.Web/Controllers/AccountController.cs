using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ChiakiYu.Common.Data;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Users;
using ChiakiYu.Web.ViewModels.Account;

namespace ChiakiYu.Web.Controllers
{
    public partial class AccountController : Controller
    {
        #region 私有字段

        private readonly IUserService _userService;

        #endregion

        #region 构造函数

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region 登录&注销

        public virtual ActionResult Login(string returnUrl = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_LoginInModal", new LoginViewModel
                {
                    ReturnUrl = returnUrl
                });
            }

            return View(
                new LoginViewModel
                {
                    ReturnUrl = returnUrl
                });
        }

        [HttpPost]
        public virtual ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = model.AsUser();
            var userLoginStatus = _userService.ValidateUser(user.UserName, user.Password);
            switch (userLoginStatus)
            {
                case UserLoginStatus.Success:
                    user =
                        _userService.GetAll()
                            .FirstOrDefault(
                                n =>
                                    n.UserName == user.UserName || n.AccountEmail == user.UserName ||
                                    n.AccountMobile == user.UserName);
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

            var adminCookie = new HttpCookie("ChiakiCookie" + user.Id) {Value = UserPasswordHelper.MD5(true.ToString())};
            if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
                adminCookie.Domain = FormsAuthentication.CookieDomain;
            adminCookie.HttpOnly = true;

            Response.Cookies.Add(adminCookie);
            FormsAuthentication.SetAuthCookie(user.UserName, model.RememberMe);

            if (string.IsNullOrWhiteSpace(model.ReturnUrl))
            {
                return RedirectToAction(MVC.Channel.Home());
            }
            return Redirect(model.ReturnUrl);
        }

        public virtual ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(MVC.Account.Login());
        }

        #endregion

        #region 注册

        /// <summary>
        ///     注册页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Register()
        {
            return View();
        }

        /// <summary>
        ///     注册页面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Register(RegisterEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = model.AsUser();
            if (_userService.AddUser(user).Id <= 0) return View(model);
            var adminCookie = new HttpCookie("ChiakiCookie" + user.UserName)
            {
                Value = UserPasswordHelper.MD5(true.ToString())
            };
            if (!string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
                adminCookie.Domain = FormsAuthentication.CookieDomain;
            adminCookie.HttpOnly = true;

            Response.Cookies.Add(adminCookie);

            FormsAuthentication.SetAuthCookie(model.UserName, false);

            return RedirectToAction(MVC.Channel.Home());
        }

        #endregion
    }
}