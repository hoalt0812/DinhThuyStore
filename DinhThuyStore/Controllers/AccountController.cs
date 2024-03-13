using DinhThuyStore.Lib;
using DinhThuyStore.Lib.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhThuyStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [Route("account")]
        public ActionResult Index()
        {
            var rs = Singleton.AccountInterface.GetAll();
            return View(rs);
        }

        [Route("account-create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("account-create")]
        public ActionResult Create(AccountDto model)
        {
            var rs = Singleton.AccountInterface.Create(model);
            return Redirect("/account");
        }

        [Route("account-checkusername")]
        public JsonResult CheckUserName(string userName)
        {
            var rs = Singleton.AccountInterface.CheckUserName(userName);
            if (rs)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(-2, JsonRequestBehavior.AllowGet);
        }

        [Route("account-delete")]
        public JsonResult Delete(int id)
        {
            var rs = Singleton.AccountInterface.Delete(id);
            if (rs > 0)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(-2, JsonRequestBehavior.AllowGet);
        }
    }
}