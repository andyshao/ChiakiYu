using System;
using System.Web.Mvc;
using ChiakiYu.Common.Data;

namespace ChiakiYu.Web.Areas.Admin.Controllers.Filters
{
    /// <summary>
    ///     后台身份验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ManageAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        private bool _checkCookie = true;

        public ManageAuthorizeAttribute()
        {
            RequireSystemAdministrator = false;
        }

        /// <summary>
        ///     是否需要系统管理员权限
        /// </summary>
        public bool RequireSystemAdministrator { get; set; }

        /// <summary>
        ///     是否需要检查Cookie
        /// </summary>
        public bool CheckCookie
        {
            get { return _checkCookie; }
            set { _checkCookie = value; }
        }

        #region IAuthorizationFilter 成员

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (AuthorizeCore(filterContext)) return;
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Controller.TempData["StatusMessageData"] = "您必须先以管理员身份登录下后台，才能继续操作！";
            }
            else
            {
                filterContext.Controller.TempData["StatusMessageData"] = "请以管理员身份登录！";
                filterContext.Result = new RedirectResult("~/Admin/ManageLogin");
            }
        }

        #endregion

        // This method must be thread-safe since it is called by the thread-safe OnCacheAuthorization() method.
        protected virtual bool AuthorizeCore(AuthorizationContext filterContext)
        {
            var currentUser = UserContext.CurrentUser;
            if (currentUser == null)
                return false;

            if (!CheckCookie) return false;
            var adminCookie = filterContext.HttpContext.Request.Cookies["ChiakiAdminCookie" + currentUser.Id];
            if (adminCookie == null) return false;
            var isLoginMarked = false;
            try
            {
                if (UserPasswordHelper.MD5(true.ToString()).Equals(adminCookie.Value))
                    isLoginMarked = true;
            }
            catch
            {
                // ignored
            }

            return isLoginMarked;
        }
    }
}