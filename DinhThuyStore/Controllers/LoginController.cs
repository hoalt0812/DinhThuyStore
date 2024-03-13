using DinhThuyStore.Lib;
using DinhThuyStore.Lib.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DinhThuyStore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [Route("signin")]
        public ActionResult Index()
        {
            if (Session["account"] != null)
                return Redirect("/");
            return View();
        }

        [Route("account-login")]
        public JsonResult AccountLogin(AccountDto model)
        {
            var dt = Singleton.AccountInterface.GetByUserNameAndPassword(model.UserName, model.Password);
            if (dt.Rows.Count > 0)
            {
                Session["account"] = dt;
                Session["username"] = dt.Rows[0]["UserName"].ToString();
                Session["role"] = dt.Rows[0]["Role"].ToString();
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(-2, JsonRequestBehavior.AllowGet);
        }

        [Route("logout")]
        public ActionResult Logout()
        {
            if (Session != null)
            {
                Session.Clear();
                Session.Abandon();
            }

            return Redirect("/");
        }
    }
}