using DinhThuyStore.Lib;
using DinhThuyStore.Lib.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhThuyStore.Controllers
{
    [PermissionRequired]
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
            ViewBag.Category = new SelectList(Singleton.CategoryInterface.GetAll(), "PKID", "CategoryName");
            return View();
        }

        [Route("product-checkproductcode")]
        public JsonResult CheckProductCode(string productCode)
        {
            var rs = Singleton.ProductInterface.CheckProductCode(productCode);
            if (rs)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(-2, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("product-create")]
        public ActionResult Create(ProductDto model)
        {
            model.Quantity = 0;
            if (model.ImageFile != null)
            {
                var image = Singleton.ImageInterface.SaveImage(model.ImageFile);
                model.Image = image;
            }
            var rs = Singleton.ProductInterface.Create(model);
            return Redirect("/product");
        }

        [Route("product-delete")]
        public JsonResult Delete(int id)
        {
            var product = Singleton.ProductInterface.GetByPKID(id);
            if (product.Image != null)
            {
                var image = Singleton.ImageInterface.DeleteImage(product.Image);
            }
            var rs = Singleton.ProductInterface.Delete(id);
            if (rs > 0)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(-2, JsonRequestBehavior.AllowGet);
        }

        [Route("product-update")]
        public ActionResult Update(int id)
        {
            var product = Singleton.ProductInterface.GetByPKID(id);
            ViewBag.Category = new SelectList(Singleton.CategoryInterface.GetAll(), "PKID", "CategoryName");
            return View(product);
        }

        [HttpPost]
        [Route("product-update")]
        public ActionResult Update(ProductDto model)
        {
            if (model.ImageFile != null)
            {
                var oldImage = model.Image;
                var image = Singleton.ImageInterface.SaveImage(model.ImageFile);
                model.Image = image;
                Singleton.ImageInterface.DeleteImage(oldImage);
            }
            var rs = Singleton.ProductInterface.Update(model);
            return Redirect("/product");
        }
    }
}