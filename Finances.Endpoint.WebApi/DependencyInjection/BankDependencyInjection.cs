namespace Finances.Endpoint.WebApi.DependencyInjection
{
    using System;
    using System.Reflection;
    using Finances.DataLayer.Repository;
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Management;
    using Ninject;
    using Ninject.Modules;

    public class BankDependencyInjection : NinjectModule
    {
        public override void Load()
        {
            //this.Bind(typeof(Lazy<>)).ToMethod(ctx =>
            //    this.GetType()
            //   .GetMethod("GetLazyProvider", BindingFlags.Instance | BindingFlags.NonPublic)
            //   .MakeGenericMethod(ctx.GenericArguments[0])
            //   .Invoke(this, new object[] { ctx.Kernel }));

            this.Bind<IBankService>().To<BankService>();
            this.Bind<IBankRepository>().To<BankRepository>();
        }

        //protected Lazy<T> GetLazyProvider<T>(IKernel kernel)
        //{
        //    return new Lazy<T>(() => kernel.Get<T>());
        //}
    }
}