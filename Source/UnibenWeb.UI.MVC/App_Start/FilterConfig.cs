using System.Web;
using System.Web.Mvc;
using UnibenWeb.Infra.CrossCutting.MvcFilters;

namespace UnibenWeb.UI.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
