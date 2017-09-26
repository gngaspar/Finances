// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceProxy.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the IServiceProxy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Tests.Mocks
{
    /// <summary>
    /// The ServiceProxy interface.
    /// </summary>
    public interface IServiceProxy
    {
        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>The service resolver.</returns>
        TService Resolve<TService>() where TService : class;
    }
}
