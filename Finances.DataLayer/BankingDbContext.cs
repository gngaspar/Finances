namespace Finances.DataLayer
{
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;
    using System.IO;

    using Finances.Domain;
    using Finances.Domain.Banking;
    using Finances.Domain.Human;

    public class BankingDbContext : DbContext
    {
        private static readonly object _lock = new object();

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

        public DbSet<CurrencyEntity> Currencies
        {
            get;
            set;
        }

        public DbSet<PersonEntity> Persons
        {
            get;
            set;
        }

        public DbSet<UserEntity> Users
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add(new BankEntityConfiguration());
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(new DataTypePropertyAttributeConvention());
        }
    }
}