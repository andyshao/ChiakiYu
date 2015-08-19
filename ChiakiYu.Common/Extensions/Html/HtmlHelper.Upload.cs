using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ChiakiYu.Common.Extensions.Html
{
    /// <summary>
    ///     分享到其他网站
    /// </summary>
    public static class HtmlHelperUploadExtensions
    {
        /// <summary>
        ///     分享到其他网站
        /// </summary>
        public static MvcHtmlString Upload(this HtmlHelper htmlHelper, string name, string allowedFileExtensions = "")
        {
            htmlHelper.ViewData["Name"] = name;
            htmlHelper.ViewData["FileExtensions"] = allowedFileExtensions;
            return htmlHelper.Partial("~/Plugins/Upload/Plupload.cshtml");
        }
    }
}