using System.Web.Optimization;

namespace ResultManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.timepicker.js",
                "~/Scripts/bootstrap-datepicker.min.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/mdb.min.css",
                "~/Content/bootstrap-datetimepicker.min.css",
                "~/Content/jquery.timepicker.min.css",
                "~/Content/bootstrap-colorpicker/css/bootstrap-colorpicker.css",
                "~/Content/jquery.ui.layout.css",
                "~/Content/bootstrap-datepicker.min.css",
                "~/Content/site.css"));

            bundles.Add(new Bundle("~/scripts/core").Include(
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/popper.min.js",
                "~/Scripts/modules/wow.js",
                "~/Scripts/mdb.min.js",
                "~/Scripts/bootstrap-datetimepicker.min.js",
                "~/Scripts/jquery-ui.unobtrusive.js",
                "~/Scripts/jquery.timepicker.js",
                "~/Scripts/bootstrap-datepicker.min.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/FontAwesome").Include(
                "~/Content/font-awesome.min.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}