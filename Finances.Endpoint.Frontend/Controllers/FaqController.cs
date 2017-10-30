// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FaqController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The faq controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Controllers
{
    using System.Web.Mvc;

    using Finances.Endpoint.Frontend.Common;
    using Finances.Endpoint.Frontend.Infrastructure;

    /// <summary>
    /// The faq controller.
    /// </summary>
    [Localization( "en" )]
    public class FaqController : BaseController
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
