using System;
using System.Web.Mvc;
using ChiakiYu.Core.AutoMapper;
using ChiakiYu.Service.Blogs;
using ChiakiYu.Service.Blogs.Dto;
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

        /// <summary>
        /// 日志首页，列表页
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Home(int pageSize = 8, int pageIndex = 1)
        {
            var input = new GetBlogsInput
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            var list = _blogService.GetBlogs(input);
            return View(list);
        }

        /// <summary>
        /// 热门日志
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public virtual ActionResult _ListHotBlogs()
        {
            var list = _blogService.GetBlogsList(5);
            return View(list);
        }

        /// <summary>
        /// 日志详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ActionResult Detail(long id)
        {
            var blog = _blogService.GetBlog(id);
            return View(blog);
        }

        /// <summary>
        /// 编辑日志
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
                AutoMapperHelper.CreateMap<Model.Blogs.Blog, BlogEditModel>();
                editModel = blog.MapTo<BlogEditModel>();
            }

            return View(editModel);
        }

        /// <summary>
        /// 编辑日志，提交表单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual JsonResult Edit(BlogEditModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { MessageType = 0, MessageContent = "数据未通过验证，请检查。" });
            AutoMapperHelper.CreateMap<BlogEditModel, Model.Blogs.Blog>();
            Model.Blogs.Blog blog;

            if (model.Id > 0)
            {
                //编辑
                blog = _blogService.GetBlog(model.Id);
                blog = model.MapTo(blog);
                blog.Author = UserContext.CurrentUser;
                blog.UpdatedTime = DateTime.Now;
                blog = _blogService.UpdateBlog(blog);
            }
            else
            {
                //新增
                blog = model.MapTo<Model.Blogs.Blog>();
                blog.Author = UserContext.CurrentUser;
                blog = _blogService.AddBlog(blog);
            }

            if (blog == null || blog.Id == 0)
                return Json(new { MessageType = 0, MessageContent = "操作失败。请重试" });
            return Json(new { MessageType = 1, MessageContent = "操作成功。" });

        }

        /// <summary>
        /// 评论列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ActionResult _CommentList(long id)
        {
            return View();
        }
    }
}