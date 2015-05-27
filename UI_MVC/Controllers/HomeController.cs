using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Filters;

namespace UI_MVC.Controllers
{
    [Authorization]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Page()
        {
            return View();
        }

    }
}
