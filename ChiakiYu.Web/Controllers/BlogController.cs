using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChiakiYu.Web.ViewModels.Blog;

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

        public virtual ActionResult Eidt(long id)
        {
            var editModel = new BlogEditModel
            {
                Id = id,
                Title = "标题第三方撒地方但是",
                SubTitle = "副标题撒的发生大标题",
                Content = "内容到富士康将分离的卡萨交房好"
            };
            return View(editModel);
        }


        public virtual ActionResult _CommentList(long id)
        {
            return View();
        }
    }
}