using System.ComponentModel.DataAnnotations;

namespace ChiakiYu.Web.ViewModels.Blog
{
    public class BlogEditModel
    {
        /// <summary>
        /// 日志Id，主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Display(Name = "副标题")]
        [DataType(DataType.Text)]
        public string SubTitle { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name = "内容")]
        [Required(ErrorMessage = "请输入内容")]
        [DataType(DataType.Text)]
        public string Content { get; set; }


    }
}