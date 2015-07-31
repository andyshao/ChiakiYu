using System.Web.Mvc;
using ChiakiYu.Core.Domain.Repositories;
using ChiakiYu.Model.Users;

namespace ChiakiYu.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<User, long> _repository;

        public HomeController(IRepository<User, long> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
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
           _repository.Insert(user);

            var userInsert = _repository.Get(2);
            userInsert.UserName = "heheh";
            _repository.Update(userInsert);


            _repository.Delete(5);


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