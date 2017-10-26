// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi
{
    using System.Web.Http;

    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    using Owin;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The start of Configuration.
        /// </summary>
        /// <param name="app">The IAppBuilder.</param>
        public void Configuration( IAppBuilder app )
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register( config );
#if DEBUG
            SwaggerConfig.Register( config );
#endif
            // DynamicModuleUtility.RegisterModule( typeof( OnePerRequestHttpModule ) );
            // DynamicModuleUtility.RegisterModule( typeof( NinjectHttpModule ) );
            app.UseNinjectMiddleware( () => NinjectConfig.CreateKernel.Value );
            app.UseNinjectWebApi( config );
        }
    }
}