﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.Frontend.Controllers
{
    using System.Web.Mvc;

    using Finances.Endpoint.Frontend.Common;
    using Finances.Endpoint.Frontend.Infrastructure;

    /// <summary>
    /// The home controller.
    /// </summary>
    [Localization( "en" )]
    public class HomeController : BaseController
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