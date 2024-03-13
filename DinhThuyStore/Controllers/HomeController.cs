using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhThuyStore.Controllers
{
    public class HomeController : Controller
    {
        [PermissionRequired]
        public ActionResult Index()
        {
            return View();
        }
    }
}