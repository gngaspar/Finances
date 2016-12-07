namespace Finances.Endpoint.WebApi.DependencyInjection
{
    using Finances.DataLayer.Repository;
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Management;
    using Ninject.Modules;

    /// <summary>
    /// The configuration of Ninject for banking
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule"/>
    public class BankingDependencyInjection : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            //this.Bind(typeof(Lazy<>)).ToMethod(ctx =>
            //    this.GetType()
            //   .GetMethod("GetLazyProvider", BindingFlags.Instance | BindingFlags.NonPublic)
            //   .MakeGenericMethod(ctx.GenericArguments[0])
            //   .Invoke(this, new object[] { ctx.Kernel }));

            this.Bind<IBankService>().To<BankService>();
            this.Bind<IBankRepository>().To<BankRepository>();

            this.Bind<ICurrencyService>().To<CurrencyService>();
            this.Bind<ICurrencyRepository>().To<CurrencyRepository>();

            this.Bind<IHumanService>().To<HumanService>();
            this.Bind<IHumanRepository>().To<HumanRepository>();


            this.Bind<IAccountService>().To<AccountService>();
            this.Bind<IAccountRepository>().To<AccountRepository>();

        }

        //protected Lazy<T> GetLazyProvider<T>(IKernel kernel)
        //{
        //    return new Lazy<T>(() => kernel.Get<T>());
        //}
    }
}