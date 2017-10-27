using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finances.Endpoint.Frontend.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        public ActionResult Index()
        {
            return View();
        }
    }
}