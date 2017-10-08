// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlasticController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the PlasticController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System.Web.Http;

    using Finances.Contract.Plastics;

    /// <summary>
    /// The Plastic Controller.
    /// </summary>
    [RoutePrefix( "Plastic" )]
    public class PlasticController : ApiController, IPlasticController
    {
    }
}
