using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChiakiYu.Web.Controllers
{
    public partial class BlogController : Controller
    {
        //
        // GET: /Blog/
        public virtual ActionResult Home()
        {
            return View();
        }

        public virtual ActionResult Detail(long id)
        {
            return View();
        }

        public virtual ActionResult _CommentList(long id)
        {
            return View();
        }
    }
}