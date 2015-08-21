using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ChiakiYu.Web.Areas.Blog.ViewModels
{
    public class BlogEditModel
    {
        /// <summary>
        ///     日志Id，主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题")]
        [StringLength(64)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Display(Name = "摘要")]
        [DataType(DataType.Text)]
        public string Summary { get; set; }

        /// <summary>
        ///     内容
        /// </summary>
        [Display(Name = "内容")]
        [Required(ErrorMessage = "请输入内容")]
        [AllowHtml]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        /// <summary>
        ///     标题图文件（带部分路径）
        /// </summary>
        [StringLength(256)]
        public string FeaturedImage { get; set; }

        /// <summary>
        ///     是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        ///     是否锁定（锁定的日志不允许评论）
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        ///     是否开启评论后查看
        /// </summary>
        public bool IsViewAfterComment { get; set; }
    }
}