using System.Web.Optimization;

namespace ChiakiYu.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(
                new StyleBundle("~/bundles/css")
                    .Include(
                        "~/Content/bootstrap/bootstrap.css",
                        "~/Content/animate/animate.css",
                        "~/Content/toastr.css",
                        "~/Scripts/sweetalert/sweet-alert.css",
                        "~/Scripts/metisMenu/metisMenu.min.css",
                        "~/Scripts/zTree/css/zTreeStyle/zTreeStyle.css",
                        "~/Content/prettyPhoto.css",
                        "~/Scripts/artDialog/css/ui-dialog.css"
                    )
                );
            //字体
            bundles.Add(
                new StyleBundle("~/Content/font-awesome/css/css")
                    .Include(
                        "~/Content/font-awesome/css/font-awesome.css"
                    )
                );

            //后台站点site
            bundles.Add(
                new StyleBundle("~/Content/admincss")
                    .Include(
                        "~/Content/adminsite.css"
                    )
                );

            //前台站点site
            bundles.Add(
                new StyleBundle("~/Content/css")
                    .Include(
                        "~/Content/Site.css"
                    )
                );


            bundles.Add(
                new ScriptBundle("~/bundles/js")
                    .Include(
                        "~/Scripts/json2.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/bootstrap/bootstrap.js",
                        "~/Scripts/modernizr-2.8.3.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/jquery.validate/jquery.validate.js",
                        "~/Scripts/jquery.validate/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate/jquery.validate.message_zh.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/sweetalert/sweet-alert.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",
                        "~/Scripts/metisMenu/metisMenu.js",
                        "~/Scripts/zTree/js/jquery.ztree.core-3.5.js",
                        "~/Scripts/zTree/js/jquery.ztree.excheck-3.5.js",

                        //"~/Scripts/plupload/plupload.full.min.js",
                        //"~/Scripts/plupload/zh_CN.js",

                        "~/Scripts/artDialog/js/dialog-plus.js",
                        "~/Scripts/others/*.js"
                    )
                );
        }
    }
}