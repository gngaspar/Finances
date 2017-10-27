using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Finances.Endpoint.Frontend.Controllers
{
    using System.Web.Mvc;

    public class FaqController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
