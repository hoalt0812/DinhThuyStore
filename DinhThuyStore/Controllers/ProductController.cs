using DinhThuyStore.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhThuyStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var rs = Singleton.ProductInterface.GetAll();
            return View(rs);
        }

        [Route("product-create")]
        public ActionResult Create()
        {
            return View();
        }
    }
}