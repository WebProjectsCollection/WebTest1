using System.Web;
using System.Web.Mvc;
using UI_MVC.Filters;

namespace UI_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizationAttribute());
        }
    }
}