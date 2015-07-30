using System;
using System.Linq;
using System.Web.Mvc;
using ChiakiYu.EntityFramework;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User user = new User
            {
                UserName = "1233",
                Password = "1232",
                NickName = "1231",
                CreatedTime = DateTime.Now
            };
            using (var context = new CodeFirstDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

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