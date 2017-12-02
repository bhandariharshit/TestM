using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestM
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            BundleTable.EnableOptimizations= true;
        }
        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            //todo log it
        }
        protected void Application_EndRequest()
        {
            var statuscode = HttpContext.Current.Response.StatusCode;
            switch (statuscode)
            {
                case 404:
                    Response.Redirect("Error");
                    break;
                case 500:
                    Response.Redirect("Error");
                    break;
                default:
                    break;
            }
        }
    }
}
