// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NinjectConfig.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The ninject config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.App_Start
{
    using System;
    using System.Reflection;

    using Finances.DataLayer;
    using Finances.DataLayer.Repository;
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Endpoint.WebApi.Infrastructure;
    using Finances.Management;

    using Ninject;
    using Ninject.Web.Common;

    /// <summary>
    /// The NINJECT config.
    /// </summary>
    public static class NinjectConfig
    {
        /// <summary>
        /// The create kernel.
        /// </summary>
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>( () =>
            {
                var kernel = new StandardKernel();
                kernel.Load( Assembly.GetExecutingAssembly() );

                RegisterServices( kernel );

                return kernel;
            } );

        /// <summary>
        /// The register services.
        /// </summary>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        private static void RegisterServices( KernelBase kernel )
        {
            //kernel.Bind<IFakeService>()
            //    .To<FakeService>();
            kernel.Bind<BankingDbContext>().ToSelf().InRequestScope();

            kernel.Bind<IBankService>().To<BankService>();
            kernel.Bind<IBankRepository>().To<BankRepository>().InRequestScope();

            kernel.Bind<ICurrencyService>().To<CurrencyService>();
            kernel.Bind<ICurrencyRepository>().To<CurrencyRepository>().InRequestScope();

            kernel.Bind<IHumanService>().To<HumanService>();
            kernel.Bind<IHumanRepository>().To<HumanRepository>().InRequestScope();

            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>().InRequestScope();

            kernel.Bind<IPlasticService>().To<PlasticService>();
            kernel.Bind<IPlasticRepository>().To<PlasticRepository>().InRequestScope();

            kernel.Bind<ICacheProvider>().To<CacheProvider>().InSingletonScope();
        }
    }
}