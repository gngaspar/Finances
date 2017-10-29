// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The bundle config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.App_Start
{
    using System.Web.Optimization;

    /// <summary>
    /// The bundle config.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">
        /// The bundles.
        /// </param>
        public static void RegisterBundles( BundleCollection bundles )
        {
            bundles.Add( new ScriptBundle( "~/Scripts/jquery" ).Include(
                "~/Scripts/jquery-3.2.1.js",
                "~/Scripts/jquery.slimscroll.js",
                "~/Scripts/jquery.validate.js" ) );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add( new ScriptBundle( "~/Scripts/modernizr" ).Include(
                "~/Scripts/modernizr-2.8.3.js" ) );

            bundles.Add( new ScriptBundle( "~/Scripts/bootstrap" ).Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-select.js",
                "~/Scripts/respond.js" ) );

            bundles.Add( new ScriptBundle( "~/Scripts/waves" ).Include(
                "~/Scripts/Plugins/node-waves/waves.js" ) );

            bundles.Add( new ScriptBundle( "~/Scripts/site" ).Include(
                "~/Js/admin.js",
                "~/Js/demo.js" ) );

            //StyleBundle
            bundles.Add( new StyleBundle( "~/Css/main" ).Include(
                "~/Css/bootstrap.css",
                "~/Css/style.css",
                "~/Css/themes/all-themes.css" ) );

            bundles.Add( new StyleBundle( "~/Css/waves" ).Include(
                "~/Scripts/Plugins/node-waves/waves.css" ) );

            bundles.Add( new StyleBundle( "~/Css/animate-css" ).Include(
                "~/Scripts/Plugins/animate-css/animate.css" ) );
        }
    }
}