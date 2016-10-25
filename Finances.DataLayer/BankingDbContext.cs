namespace Finances.DataLayer
{
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;
    using System.IO;

    using Finances.Domain.Banking;
    public class BankingDbContext : DbContext
    {
        static readonly object _lock = new object();

        public BankingDbContext()
            : base("BankingConnection")
        {
            Database.SetInitializer<BankingDbContext>(null);
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;

            var ensureDllIsCopied = SqlProviderServices.Instance;

#if DEBUG
            this.Database.Log = s =>
            {
                lock (_lock)
                {
                    File.AppendAllText(@"C:/DBLog.txt", s);
                }
            };
#endif
        }

        public DbSet<BankEntity> Banks
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new BankEntityConfiguration());

            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }


}
