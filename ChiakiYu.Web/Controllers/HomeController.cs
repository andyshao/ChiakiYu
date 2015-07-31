using System.Web.Mvc;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = new User
            {
                UserName = "123",
                Password = "123",
                NickName = "123",
                PasswordFormat = UserPasswordFormat.Clear,
                IsEmailVerified = false,
                IsMobileVerified = false
            };

            //using (var context = new ChiakiYuDbContext())
            //{
            //    context.Set<User>().Add(user);
            //    context.SaveChanges();
            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}