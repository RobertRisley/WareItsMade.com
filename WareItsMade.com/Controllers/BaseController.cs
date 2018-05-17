using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareItsMade.com.Models;

namespace WareItsMade.com.Controllers
{
    public class BaseController : Controller
    {
        public SessionData SessionData;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Session["SessionData"] == null)
                Session["SessionData"] = SessionDataController.DefaultSessionData;

            if (Session["caption"] == null)
                Session["caption"] = string.Empty;

            SessionData = Session["SessionData"] as SessionData;
        }
    }
}