using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Filters;

namespace UI_MVC.Controllers
{
    [Authorization]
    public class UserController : Controller
    {
        //
        // GET: /User/
        [HttpGet]
        [AllowAnonymous]//这里是一个特例，有这个特性，表示这个方法不需要验证用户登录状态
        public ActionResult Login()
        {
            if (Request.Cookies["LoginedUser"] != null)
            {
                Response.Redirect("/Home/Page.html");
                return null;
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]//这里是一个特例，有这个特性，表示这个方法不需要验证用户登录状态
        public ActionResult Login(string userName, string password)
        {
            // username=yx&password=123
            if (userName == "yx" && password == "123")
            {
                HttpCookie _cookie = new HttpCookie("LoginedUser");
                _cookie.Values.Add("name", "yangxun");
                Response.Cookies.Add(_cookie);
                return Json(new { Message = "OK" });
            }
            else
            {
                return Json(new { Message = "Error" });
            }
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["LoginedUser"] != null)
            {
                HttpCookie _cookie = Request.Cookies["LoginedUser"];
                _cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(_cookie);
            }
            Response.Redirect("/User/Login.html");
            return null;
        }

    }
}
