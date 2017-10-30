// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignInController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the SignInController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Controllers
{
    using System.Web.Mvc;

    using Finances.Endpoint.Frontend.Infrastructure;

    /// <summary>
    /// The sign in controller.
    /// </summary>
    [Localization( "en" )]
    public class SignInController : Controller
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