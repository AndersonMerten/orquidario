using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.Optimization;

namespace ControleEstoque
{
      public class AsIsBundleOrderer : IBundleOrderer
      {
            public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
            {
                  return files;
            }
      }

      public class BundleConfig
      {
            // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
            public static void RegisterBundles(BundleCollection bundles)
            {
                  bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                              "~/Scripts/jquery-{version}.js"));

                  var bundle = new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/modelo-pt.js",
                        "~/Scripts/helper.js"
                        );
                  bundle.Orderer = new AsIsBundleOrderer();
                  bundles.Add(bundle);


                  // Use the development version of Modernizr to develop with and learn from. Then, when you're
                  // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
                  bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

                  bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                            "~/Scripts/bootstrap.js",
                            "~/Scripts/respond.js"));

                  bundles.Add(new StyleBundle("~/Content/css").Include(
                            "~/Content/bootstrap.css",
                            "~/Content/site.css"));
            }
      }
}
