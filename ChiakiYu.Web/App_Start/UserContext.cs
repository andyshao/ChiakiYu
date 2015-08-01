using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Autofac;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Users;
using ChiakiYu.Service.Users;

namespace ChiakiYu.Web
{
    public class UserContext
    {

        /// <summary>
        ///     获取当前用户
        /// </summary>
        public static User CurrentUser
        {
            get
            {
                var currentUser = GetAuthenticatedUser();
                return currentUser;

                //string token = string.Empty;
                //if (HttpContext.Current != null && HttpContext.Current.Request != null)
                //{

                //    token = HttpContext.Current.Request.Form.GetRole<string>("CurrentUserIdToken", string.Empty);

                //    if (string.IsNullOrEmpty(token))
                //        token = HttpContext.Current.Request.QueryString.GetRole<string>("CurrentUserIdToken", string.Empty);
                //}
            }
        }

        /// <summary>
        ///     获取当前认证的用户
        /// </summary>
        /// <returns>
        ///     当前用户未通过认证则返回null
        /// </returns>
        private static User GetAuthenticatedUser()
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null || !httpContext.Request.IsAuthenticated ||
                !(httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            return DependencyResolver.Current.GetService<IUserService>().GetAll().FirstOrDefault(n => n.UserName == httpContext.User.Identity.Name);

            //return UserService.GetAll()
        }
    }
}