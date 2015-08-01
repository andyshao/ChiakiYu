using System.Web.Optimization;

namespace ChiakiYu.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //VENDOR RESOURCES

            //~/Bundles/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                    .Include(
                        "~/Content/themes/base/all.css",
                        "~/Content/bootstrap/bootstrap.css",
                        "~/Content/animate/animate.css",
                        "~/Content/toastr.css",
                        "~/Scripts/sweetalert/sweet-alert.css",
                        "~/Content/flags/famfamfam-flags.css",
                        "~/Content/font-awesome/css/font-awesome.css",
                        "~/Scripts/metisMenu/metisMenu.min.css",
                        "~/Scripts/zTree/css/zTreeStyle/zTreeStyle.css",
                        "~/Content/prettyPhoto.css",
                        "~/Scripts/artDialog/css/ui-dialog.css"
                    )
                );

            //~/Bundles/vendor/js/top (These scripts should be included in the head of the page)
            bundles.Add(
                new ScriptBundle("~/Bundles/js/top")
                    .Include(
                        "~/Abp/Framework/scripts/utils/ie10fix.js",
                        "~/Scripts/modernizr-2.8.3.js"
                    )
                );

            //~/Bundles/vendor/bottom (Included in the bottom for fast page load)
            bundles.Add(
                new ScriptBundle("~/Bundles/js/bottom")
                    .Include(
                        "~/Scripts/json2.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/bootstrap/bootstrap.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/jquery.validate/jquery.validate.js",
                        "~/Scripts/jquery.validate/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate/jquery.validate.message_zh.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/sweetalert/sweet-alert.js",
                        "~/Scripts/others/spinjs/spin.js",
                        "~/Scripts/others/spinjs/jquery.spin.js",
                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
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