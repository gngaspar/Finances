// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the RegisterController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Controllers
{
    using System.Web.Mvc;

    using Finances.Endpoint.Frontend.Infrastructure;

    /// <summary>
    /// The register controller.
    /// </summary>
    [Localization( "en" )]
    public class RegisterController : Controller
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