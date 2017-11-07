using System.Web;
using System.Web.Optimization;

namespace Web.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/SweetAlert/dist/sweetalert.min.js",
                      "~/Content/bootstrap-select-1.12.1/dist/js/bootstrap-select.min.js",
                      "~/Content/bootstrap-select-1.12.1/js/i18n/defaults-pt_BR.js"));
                
             bundles.Add(new ScriptBundle("~/bundles/notify").Include("~/Scripts/bootstrapNotify/bootstrap-notify.js"));
            bundles.Add(new ScriptBundle("~/bundles/utils").Include("~/Scripts/UtilsJs.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css", 
                      "~/Content/reset.css",
                      "~/Scripts/SweetAlert/dist/sweetalert.css",
                      "~/Content/bootstrap-select-1.12.1/dist/css/bootstrap-select.min.css"));

        }
    }
}
