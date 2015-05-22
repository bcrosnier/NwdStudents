using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nwd.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
        public ActionResult InternalServerError()
        {
            Response.StatusCode = 500;

            Exception ex = (Exception)HttpContext.Cache["LastError"];

            return View( ex );
        }
    }
}