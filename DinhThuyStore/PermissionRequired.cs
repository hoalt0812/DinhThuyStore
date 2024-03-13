using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhThuyStore
{
    public class PermissionRequired : ActionFilterAttribute
    {
        private HttpSessionStateBase _session;

        protected DataTable CurrUser
        {
            get { return _session["account"] == null ? null : (DataTable)_session["account"]; }
            set { _session["account"] = value; }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase context = filterContext.HttpContext;
            HttpRequestBase _request = context.Request;
            _session = context.Session;

            if (CurrUser?.Rows.Count > 0)
                return;

            if (_request.Url != null)
                filterContext.Result = new RedirectResult("/signin");
        }
    }
}