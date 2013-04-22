using System.Web;
using System.Web.Optimization;

namespace PublicMvc
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap*",
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/modernizr-*"
                        ));


            bundles.Add(new StyleBundle("~/Content/styles").Include(
                "~/Content/bootstrap.css",
                "~/Content/flat-ui.css",
                "~/Content/site.css"
                ));

        }
    }
}