﻿using CinemaOnline.Areas.Admin.Authorization;
using System.Web.Mvc;

namespace CinemaOnline.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: /Administrator/Base/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!CookiesManage.Logined())
            {
                var returnUrl = filterContext.HttpContext.Request.RawUrl;
                filterContext.Result =
                new RedirectResult(string.Concat("~/Admin/Login/Index", "?ReturnUrl=", returnUrl));
            }
            base.OnActionExecuting(filterContext);
        }

        public static BELibrary.Entity.Admin GetCurrentUser()
        {
            return CookiesManage.GetUser();
        }
    }
}