// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgotPasswordController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The forgot password controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Controllers
{
    using System.Web.Mvc;

    using Finances.Endpoint.Frontend.Infrastructure;

    /// <summary>
    /// The forgot password controller.
    /// </summary>
    [Localization( "en" )]
    public class ForgotPasswordController : Controller
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