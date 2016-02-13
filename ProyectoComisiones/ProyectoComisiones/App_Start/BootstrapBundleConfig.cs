using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace BootstrapSupport
{



    public class BootstrapBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/jquery-2.1.4.js",
                "~/Scripts/jquery-migrate-1.2.1.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.validate.js",
                "~/scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.index.js",
                "~/Scripts/jquery.validate.unobtrusive-custom-for-bootstrap.js",
                "~/js_/jquery.min.js",
                 "~/js_/angular.min.js",
                  "~/js_/kendo.all.min.js",
                  "~/js_/cultures/kendo.culture.es-ES.min.js"
                ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/body.css",
                "~/Content/bootstrap-responsive.css",
                "~/Content/bootstrap-mvc-validation.css",
                "~/styles/kendo.common.min.css",
                "~/styles/kendo.rtl.min.css",
                "~/styles/kendo.default.min.css",
                "~/styles/kendo.dataviz.min.css",
                "~/styles/kendo.dataviz.default.min.css",
                "~/styles/kendo.default.mobile.min.css"
                ));

            




        }
    }
}