using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finances.Endpoint.WebApi
{
    using System.Web.Http;

    using Finances.Endpoint.WebApi.App_Start;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject.Web.Common;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    using Owin;

    public class Startup
    {
        public void Configuration( IAppBuilder app )
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register( config );
            SwaggerConfig.Register( config );

            // DynamicModuleUtility.RegisterModule( typeof( OnePerRequestHttpModule ) );
            // DynamicModuleUtility.RegisterModule( typeof( NinjectHttpModule ) );

            app.UseNinjectMiddleware( () => NinjectConfig.CreateKernel.Value );
            app.UseNinjectWebApi( config );
        }
    }
}