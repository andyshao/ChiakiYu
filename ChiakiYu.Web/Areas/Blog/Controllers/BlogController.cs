using System.Web.Mvc;
using AutoMapper;
using ChiakiYu.Core.AutoMapper;
using ChiakiYu.Service.Blogs;
using ChiakiYu.Web.Areas.Blog.ViewModels;

namespace ChiakiYu.Web.Areas.Blog.Controllers
{
    public partial class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public virtual ActionResult Home()
        {
            return View();
        }

        public virtual ActionResult Detail(long id)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult Edit(long? id = null)
        {
            var editModel = new BlogEditModel();
            if (id.HasValue && id.Value > 0)
            {
                var blog = _blogService.GetBlog(id.Value);
                Mapper.CreateMap<Model.Blogs.Blog, BlogEditModel>();
                editModel = blog.MapTo<BlogEditModel>();
            }

            return View(editModel);
        }

        [HttpPost]
        public virtual JsonResult Edit(BlogEditModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { MessageType = 0, MessageContent = "数据未通过验证，请检查。" });
            model.Author = UserContext.CurrentUser;
            Mapper.CreateMap<BlogEditModel, Model.Blogs.Blog>();
            var blog = model.MapTo<Model.Blogs.Blog>();
            blog = _blogService.AddOrUpdateBlog(blog);
            if (blog == null || blog.Id == 0)
                return Json(new { MessageType = 0, MessageContent = "操作失败。请重试" });
            return Json(new { MessageType = 1, MessageContent = "操作成功。" });

        }


        public virtual ActionResult _CommentList(long id)
        {
            return View();
        }
    }
}