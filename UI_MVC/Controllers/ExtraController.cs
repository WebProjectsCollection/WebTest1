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
        [AllowAnonymous]
        public ActionResult Lock(string backUrl)
        {
            HttpCookie cookie = Request.Cookies[Config.AuthSaveKey];
            if (cookie == null || Identity.UserInfo.LoginedUserInfo == null)
            {
                Response.Redirect(Config.LoginUrl);
                return null;
            }
            // 添加锁定Cookies,把要返回的url也写到cookies里
            if (cookie.Values["islocked"] != "islocked")
            {
                cookie.Values.Add("islocked", "islocked");
                cookie.Values.Add("backurl", backUrl ?? "/");
                Response.Cookies.Add(cookie);
            }
            ViewBag.BackUrl = cookie.Values["backurl"] == null || cookie.Values["backurl"].ToString().Trim() == "" ? "/" : cookie.Values["backurl"].ToString();
            ViewBag.UserName = Identity.UserInfo.LoginedUserInfo.UserName;
            ViewBag.UserEmail = Identity.UserInfo.LoginedUserInfo.Email;
            return View();

        }
    }
}
