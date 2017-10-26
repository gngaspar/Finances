// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the LoginController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The login controller.
    /// </summary>
    public class LoginController : Controller
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