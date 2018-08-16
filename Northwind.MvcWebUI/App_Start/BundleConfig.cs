using System.Web;
using System.Web.Optimization;

namespace Northwind.MvcWebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/light-bootstrap-dashboard-master/assets/js/jquery.3.2.1.min.js",     //Core JS Files
                        "~/Content/light-bootstrap-dashboard-master/assets/js/bootstrap.min.js",
                        "~/Content/light-bootstrap-dashboard-master/assets/js/chartist.min.js",         //Charts Plugin
                        "~/Content/light-bootstrap-dashboard-master/assets/js/bootstrap-notify.js",     //Notifications Plugin
                        "~/Content/light-bootstrap-dashboard-master/assets/js/light-bootstrap-dashboard.js?v=1.4.0", //Light Bootstrap Table Core javascript and methods for Demo purpose
                        "~/Content/light-bootstrap-dashboard-master/assets/js/demo.js"  //Light Bootstrap Table DEMO methods, don't include it in your project



                        ));

     

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/light-bootstrap-dashboard-master/assets/css/bootstrap.min.css",    //Bootstrap core CSS
                      "~/Content/light-bootstrap-dashboard-master/assets/css/animate.min.css",       //Animation library for notifications
                      "~/Content/light-bootstrap-dashboard-master/assets/css/light-bootstrap-dashboard.css?v=1.4.0",       //Light Bootstrap Table core CSS
                      "~/Content/light-bootstrap-dashboard-master/assets/css/pe-icon-7-stroke.css",  
                      "~/Content/light-bootstrap-dashboard-master/assets/css/demo.css"       //CSS for Demo Purpose, don't include it in your project
                      ));
        }
    }
}
