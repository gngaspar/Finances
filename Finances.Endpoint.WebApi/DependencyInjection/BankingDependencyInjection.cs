// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankingDependencyInjection.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The configuration of Ninject for banking
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.DependencyInjection
{
    using Finances.DataLayer;
    using Finances.DataLayer.Repository;
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Management;
    using Ninject.Modules;
    using Ninject.Web.Common;

    /// <summary>
    /// The configuration of NINJECT for banking
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule"/>
    public class BankingDependencyInjection : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            ////this.Bind(typeof(Lazy<>)).ToMethod(ctx =>
            ////    this.GetType()
            ////   .GetMethod("GetLazyProvider", BindingFlags.Instance | BindingFlags.NonPublic)
            ////   .MakeGenericMethod(ctx.GenericArguments[0])
            ////   .Invoke(this, new object[] { ctx.Kernel }));
            this.Bind<BankingDbContext>().ToSelf().InRequestScope();

            this.Bind<IBankService>().To<BankService>();
            this.Bind<IBankRepository>().To<BankRepository>().InRequestScope();

            this.Bind<ICurrencyService>().To<CurrencyService>();
            this.Bind<ICurrencyRepository>().To<CurrencyRepository>().InRequestScope();

            this.Bind<IHumanService>().To<HumanService>();
            this.Bind<IHumanRepository>().To<HumanRepository>().InRequestScope();

            this.Bind<IAccountService>().To<AccountService>();
            this.Bind<IAccountRepository>().To<AccountRepository>().InRequestScope();
        }

        //protected Lazy<T> GetLazyProvider<T>(IKernel kernel)
        //{
        //    return new Lazy<T>(() => kernel.Get<T>());
        //}
    }
}