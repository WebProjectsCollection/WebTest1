using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Common;
using UI_MVC.Filters;

namespace UI_MVC.Controllers
{
    public class SysController : Controller
    {
        //
        // GET: /NotFound/
      
        public ActionResult NotFound()
        {
            return View();
        }

    }
}
