using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ChiakiYu.Common.Extensions.Html
{
    /// <summary>
    ///     分享到其他网站
    /// </summary>
    public static class HtmlHelperShareToThirdExtensions
    {
        /// <summary>
        ///     分享到其他网站
        /// </summary>
        public static MvcHtmlString ShareToThird(this HtmlHelper htmlHelper,
            ShareDisplayType shareDisplayType = ShareDisplayType.Icon,
            ShareDisplayIconSize shareDisplayIconSize = ShareDisplayIconSize.Middle)
        {
            //展示形式
            htmlHelper.ViewData["ShareToThirdDisplayType"] = shareDisplayType;
            //图标形式展示大小
            htmlHelper.ViewData["ShareDisplayIconSize"] = shareDisplayIconSize;
            return htmlHelper.Partial("~/Plugins/ShareToThird/Baidu.cshtml");
        }
    }

    /// <summary>
    ///     分享到站外展示形式
    /// </summary>
    public enum ShareDisplayType
    {
        /// <summary>
        ///     文字
        /// </summary>
        [Display(Name = "文字")]
        Word,

        /// <summary>
        ///     图标
        /// </summary>
        [Display(Name = "图标")]
        Icon,

        /// <summary>
        ///     侧栏
        /// </summary>
        [Display(Name = "侧栏")]
        Sidebar
    }

    /// <summary>
    ///     分享到站外图标形式展示大小
    /// </summary>
    public enum ShareDisplayIconSize
    {
        /// <summary>
        ///     大图标32*32
        /// </summary>
        [Display(Name = "大图标")]
        Big = 32,

        /// <summary>
        ///     中图标24*24
        /// </summary>
        [Display(Name = "中图标")]
        Middle = 24,

        /// <summary>
        ///     小图标16*16
        /// </summary>
        [Display(Name = "小图标")]
        Small = 16
    }
}