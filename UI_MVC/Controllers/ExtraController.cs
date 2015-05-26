using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Filters;

namespace UI_MVC.Controllers
{
    public class ExtraController : Controller
    {
        //
        // GET: /Extra/
         [Authorization]
        public ActionResult Lock()
        {
            ViewBag.UserName="yangxun";
            ViewBag.UserEmail = "yangxun@outlook.com";
            return View();
        }

    }
}
