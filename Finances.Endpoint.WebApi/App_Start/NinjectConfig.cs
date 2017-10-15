// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NinjectConfig.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The ninject config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi
{
    using System;
    using System.Reflection;

    using Finances.Contract.Accounting;
    using Finances.Contract.Banking;
    using Finances.Contract.Humans;
    using Finances.Contract.Parameterizations;
    using Finances.Contract.Plastics;
    using Finances.DataLayer;
    using Finances.DataLayer.Repository;
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Endpoint.WebApi.ApiControllers;
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

            kernel.Bind<IBankController>().To<BankController>();
            kernel.Bind<IBankService>().To<BankService>();
            kernel.Bind<IBankRepository>().To<BankRepository>().InRequestScope();

            kernel.Bind<ICurrencyController>().To<CurrencyController>();
            kernel.Bind<ICurrencyService>().To<CurrencyService>();
            kernel.Bind<ICurrencyRepository>().To<CurrencyRepository>().InRequestScope();

            kernel.Bind<IHumanController>().To<HumanController>();
            kernel.Bind<IHumanService>().To<HumanService>();
            kernel.Bind<IHumanRepository>().To<HumanRepository>().InRequestScope();

            kernel.Bind<IAccountController>().To<AccountController>();
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>().InRequestScope();

            kernel.Bind<IPlasticController>().To<PlasticController>();
            kernel.Bind<IPlasticService>().To<PlasticService>();
            kernel.Bind<IPlasticRepository>().To<PlasticRepository>().InRequestScope();

            kernel.Bind<IParameterizationsController>().To<ParameterizationsController>();
            kernel.Bind<IParameterizationsService>().To<ParameterizationsService>();
            kernel.Bind<IParameterizationsRepository>().To<ParameterizationsRepository>().InRequestScope();

            kernel.Bind<ICacheProvider>().To<CacheProvider>().InSingletonScope();
        }
    }
}