using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;
using ChiakiYu.Common.Web;

namespace ChiakiYu.Web
{
    /// <summary>
    ///     js和css的捆绑压缩
    /// </summary>
    public static class BundleConfig
    {
        /// <summary>
        ///     注册捆绑压缩
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(
                new StyleBundle("~/bundles/admin/css")
                    .Include(
                        "~/Content/bootstrap/bootstrap.css",
                        "~/Content/animate/animate.css",
                        "~/Content/toastr.css",
                        "~/Content/AdminLTE.css",
                        "~/Content/skins/_all-skins.css",
                        "~/Scripts/zTree/css/zTreeStyle/zTreeStyle.css",
                        "~/Scripts/artDialog/css/ui-dialog.css"
                    )
                );
            bundles.Add(
                new StyleBundle("~/bundles/css")
                    .Include(
                        "~/Content/bootstrap/bootstrap.css",
                        "~/Content/animate/animate.css",
                        "~/Content/toastr.css",
                        "~/Scripts/artDialog/css/ui-dialog.css",
                        "~/Content/main.css",
                        "~/Content/responsive.css"
                    )
                );
            //字体图标
            bundles.Add(
                new StyleBundle("~/Content/font-awesome/css/css")
                    .Include(
                        "~/Content/font-awesome/css/font-awesome.css"
                    )
                );

            //fancybox
            bundles.Add(
                new StyleBundle("~/Scripts/fancybox/css")
                    .Include(
                        "~/Scripts/fancybox/jquery.fancybox.css",
                        "~/Scripts/fancybox/helpers/jquery.fancybox-thumbs.css"
                    //"~/Scripts/fancybox/helpers/jquery.fancybox-buttons.css"
                    )
                );

            bundles.Add(
                new ScriptBundle("~/bundles/jquery")
                    .Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/bootstrap/bootstrap.js"
                    )
                );

            bundles.Add(
                new ScriptBundle("~/bundles/admin/js")
                    .Include(
                        "~/Scripts/json2.js",
                        "~/Scripts/modernizr-2.8.3.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/jquery.validate/jquery.validate.js",
                        "~/Scripts/jquery.validate/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate/jquery.validate.message_zh.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/luckyyu/app.js",
                        "~/Scripts/slimScroll/jquery.slimscroll.js",
                        "~/Scripts/zTree/js/jquery.ztree.core-3.5.js",
                        "~/Scripts/zTree/js/jquery.ztree.excheck-3.5.js",
                        "~/Scripts/artDialog/js/dialog-plus.js"
                    )
                );
            bundles.Add(
                new ScriptBundle("~/bundles/js")
                    .Include(
                        "~/Scripts/json2.js",
                        "~/Scripts/modernizr-2.8.3.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/jquery.validate/jquery.validate.js",
                        "~/Scripts/jquery.validate/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate/jquery.validate.message_zh.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/artDialog/js/dialog-plus.js",
                        "~/Scripts/fancybox/jquery.fancybox.js",
                        "~/Scripts/fancybox/helpers/jquery.fancybox-thumbs.js",
                        "~/Scripts/wow/wow.min.js",
                        "~/Scripts/luckyyu/main.js",
                        "~/Scripts/luckyyu/lucky.plugin.js"
                    )
                );

            //UEditor
            bundles.Add(new ScriptBundle("~/Scripts/UEditor/Js")
                .Include("~/Scripts/UEditor/ueditor.config.js")
                .Include("~/Scripts/UEditor/ueditor.all.js")
                .Include("~/Scripts/UEditor/ueditor.parse.js")
                );

            //plupload
            bundles.Add(new ScriptBundle("~/bundles/plupload")
                .Include(
                    "~/Scripts/plupload/plupload.js",
                    "~/Scripts/plupload/i18n/zh_CN.js.js"
                ));
        }
    }


    public class FixCssRewrite : IItemTransform
    {
        public string Process(string includedVirtualPath, string input)
        {
            if (includedVirtualPath == null)
            {
                throw new ArgumentNullException("includedVirtualPath");
            }
            return ConvertUrlsToAbsolute(VirtualPathUtility.GetDirectory(WebHelper.ResolveUrl(includedVirtualPath)),
                input);
        }

        private string ConvertUrlsToAbsolute(string baseUrl, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return content;
            }
            var regex = new Regex("url\\(['\"]?(?<url>[^)]+?)['\"]?\\)");
            return regex.Replace(content,
                match => ("url(" + RebaseUrlToAbsolute(baseUrl, match.Groups["url"].Value) + ")"));
        }

        private string RebaseUrlToAbsolute(string baseUrl, string url)
        {
            if ((string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(baseUrl)) ||
                url.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                return url;
            }
            if (!baseUrl.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                baseUrl = baseUrl + "/";
            }
            return WebHelper.ResolveUrl(VirtualPathUtility.ToAbsolute(baseUrl + url));
        }
    }
}