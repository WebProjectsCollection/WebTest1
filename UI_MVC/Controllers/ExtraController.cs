using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_MVC.Controllers
{
    public class ExtraController : Controller
    {
        //
        // GET: /Extra/

        public ActionResult Lock()
        {
            ViewBag.UserName="yangxun";
            ViewBag.UserEmail = "yangxun@outlook.com";
            return View();
        }

    }
}
