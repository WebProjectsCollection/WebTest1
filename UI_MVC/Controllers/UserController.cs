using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_MVC.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            // username=yx&password=123
            if (userName == "yx" && password == "123")
            {
                return Json(new { Message = "OK" });
            }
            else
            {
                return Json(new { Message = "Error" });
            }
        }

    }
}
