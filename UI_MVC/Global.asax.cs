using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace UI_MVC
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var lastError = Server.GetLastError();
            if (lastError != null)
            {
                var httpError = lastError as HttpException;
                //var url = HttpContext.Current.Request.Url; // 请求信息
                if (httpError != null)
                {
                    //ASP.NET的400与404错误不记录日志，并都以自定义404页面响应
                    var httpCode = httpError.GetHttpCode();
                    if (httpCode == 400 || httpCode == 404)
                    {
                        //Response.StatusCode = 404;//在IIS中配置自定义404页面（不会配呀）
                        HttpContext.Current.Response.Redirect("~/NotFound.html", true);
                        Server.ClearError();
                        return;
                    }
                    //  记录日志：Logger.Default.Error("Application_Error_" + httpCode, httpError);
                }

                //对于路径错误不记录日志，并都以自定义404页面响应
                if (lastError.TargetSite.ReflectedType == typeof(System.IO.Path))
                {
                    //Response.StatusCode = 404;
                    HttpContext.Current.Response.Redirect("~/NotFound.html", true);
                    Server.ClearError();
                    return;
                }

                // 记录日志：Logger.Default.Error("Application_Error", lastError);
                Response.StatusCode = 500;
                Server.ClearError();
            }
        }

    }
}