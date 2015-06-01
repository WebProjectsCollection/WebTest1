using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Filters;
using Tools;
using System.Data;

namespace UI_MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Page(string username = "yangxun", string pwd = "123")
        {
            return View();
        }

    }
}
