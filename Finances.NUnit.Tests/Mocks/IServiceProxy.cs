using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.NUnit.Tests.Mocks
{
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
