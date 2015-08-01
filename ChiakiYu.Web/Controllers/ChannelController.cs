using System.Web.Mvc;
using ChiakiYu.Common.Data;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Web.Controllers
{
    public partial class ChannelController : Controller
    {
        public ChannelController()
        {
        }

        public virtual ActionResult Home()
        {
            var user = new User
            {
                UserName = "1231",
                Password = "1231",
                NickName = "1231",
                PasswordFormat = UserPasswordFormat.Clear,
                IsEmailVerified = false,
                IsMobileVerified = false
            };
            return View();
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}