using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Common;
using UI_MVC.Filters;

namespace UI_MVC.Controllers
{
    public class ExtraController : Controller
    {
        [Authorization(IsLocked="islocked")]
        public ActionResult Lock()
        {
            // 添加锁定Cookies
            HttpCookie cookie = Request.Cookies[Config.AuthSaveKey];
            if (cookie != null && cookie.Values["islocked"] != "islocked")
            {
                cookie.Values.Add("islocked", "islocked");
                Response.Cookies.Add(cookie);
            }
            ViewBag.UserName = "yangxun";
            ViewBag.UserEmail = "yangxun@outlook.com";
            return View();
        }
    }
}
