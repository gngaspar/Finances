// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlasticService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the ICardService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Plastics;

    /// <summary>
    /// The CardService interface.
    /// </summary>
    public interface IPlasticService
    {
        Task<CardListResponse> List( Guid owner, CardListRequest request );
    }
}
