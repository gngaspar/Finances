// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceProxyMock.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The service proxy mock.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Tests.Mocks
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Moq;

    /// <summary>
    /// The service proxy mock.
    /// </summary>
    public class ServiceProxyMock : BaseMock<IServiceProxy>
    {
        /// <summary>
        /// The service proxy mock.
        /// </summary>
        private readonly Mock<IServiceProxy> serviceProxyMock;

        /// <summary>
        /// The mocks.
        /// </summary>
        private readonly IDictionary<Type, BaseMock> mocks = new ConcurrentDictionary<Type, BaseMock>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProxyMock"/> class.
        /// </summary>
        public ServiceProxyMock()
        {
            this.serviceProxyMock = (Mock<IServiceProxy>) Create();
            if ( this.mocks.Count == 0 )
            {
                this.RegisterProxyMocks();
            }
        }

        /// <summary>
        /// Gets the mock.
        /// </summary>
        public Mock<IServiceProxy> Mock => this.serviceProxyMock;

        /// <summary>
        /// The get mock.
        /// </summary>
        /// <typeparam name="T">
        /// The Type of object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Mock"/>.
        /// </returns>
        public Mock<T> GetMock<T>() where T : class
        {
            BaseMock mock;
            if ( this.mocks.TryGetValue( typeof( T ), out mock ) )
            {
                return mock.Create() as Mock<T>;
            }

            return null;
        }

        /// <summary>
        /// The setup.
        /// </summary>
        /// <param name="mock">
        /// The mock.
        /// </param>
        public override void Setup( Mock<IServiceProxy> mock )
        {
        }

        /// <summary>
        /// The register proxy mocks.
        /// </summary>
        private void RegisterProxyMocks()
        {
            var assembly = AppDomain.CurrentDomain.
                GetAssemblies().FirstOrDefault( x => x.FullName.StartsWith( "Finances.NUnit.Tests", StringComparison.Ordinal ) );

            var types = assembly.GetTypes().Where( x => x.IsClass
                && x.IsSubclassOf( typeof( BaseMock ) )
                && x != typeof( BaseMock )
                && x != typeof( ServiceProxyMock )
                && x.IsGenericType == false &&
                x.Namespace.StartsWith( "Finances.NUnit.Tests.Mocks", StringComparison.Ordinal ) ).Distinct().ToList();

            foreach ( var type in types )
            {
                var mockObject = (BaseMock) Activator.CreateInstance( type );
                var mockType = mockObject.GetMockType();
                this.mocks[ mockType ] = mockObject;

                var input = Expression.Parameter( typeof( IServiceProxy ), "input" );
                var method = typeof( IServiceProxy ).GetMethod( "Resolve" ).MakeGenericMethod( mockType );

                var result = Expression.Lambda<Func<IServiceProxy, object>>( Expression.Call( input, method ), input );
                this.serviceProxyMock.Setup( result ).Returns( () => ( mockObject.Create() as Mock ).Object );
            }
        }
    }
}