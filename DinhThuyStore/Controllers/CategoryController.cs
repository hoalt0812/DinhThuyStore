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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var rs = Singleton.CategoryInterface.GetAll();
            return View(rs);
        }

        [Route("category-create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("category-create")]
        public ActionResult Create(CategoryDto model)
        {
            var rs = Singleton.CategoryInterface.Create(model);
            return Redirect("/category");
        }

        [Route("category-checkcategoryname")]
        public JsonResult CheckCategoryName(string categoryName)
        {
            var rs = Singleton.CategoryInterface.CheckCategoryName(categoryName);
            if (rs)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(-2, JsonRequestBehavior.AllowGet);
        }

        [Route("category-delete")]
        public JsonResult Delete(int id)
        {
            var categories = Singleton.ProductInterface.GetByCategoryID(id);
            if (categories.Count > 0)
            {
                foreach (var item in categories)
                {
                    if(item.Image.Trim() != "")
                    {
                        Singleton.ImageInterface.DeleteImage(item.Image);
                    }
                }
            }
            var rs = Singleton.CategoryInterface.Delete(id);
            if (rs > 0)
            {              
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(-2, JsonRequestBehavior.AllowGet);
        }
    }
}