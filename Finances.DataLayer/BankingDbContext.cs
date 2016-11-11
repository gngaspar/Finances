namespace Finances.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Finances.DataLayer.Conventions;
    using Finances.Domain;
    using Finances.Domain.Accounting;
    using Finances.Domain.Banking;
    using Finances.Domain.Human;
    using Finances.Domain.Plastic;
    using Finances.Domain.Projection;

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
                        try
                        {
                            string path = @"C:\Git\Logs";
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }

                            File.AppendAllText(@"C:\Git\Logs\DBLog.txt", s);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                };
#endif
        }

        public override int SaveChanges()
        {
            this.SetCreatedDate();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            this.SetCreatedDate();

            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            this.SetCreatedDate();

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<CardEntity> Cards { get; set; }

        public DbSet<BankEntity> Banks { get; set; }

        public DbSet<CurrencyEntity> Currencies { get; set; }

        public DbSet<CurrencyHistoryEntity> CurrencyHistory { get; set; }

        public DbSet<PersonEntity> Persons { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<AccountEntity> Accounts { get; set; }

        public DbSet<ParameterizationEntity> Parameterizations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DataTypePropertyAttributeConvention());
            modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        private void SetCreatedDate()
        {
            var addedEntities = this.ChangeTracker.Entries<EntityDateTimeBase>().Where(e => e.State == EntityState.Added).ToList();

            addedEntities.ForEach(e =>
            {
                e.Entity.CreatedAt = DateTime.Now;
                e.Entity.ChangeAt = DateTime.Now;
            });

            var modifiefEntities = this.ChangeTracker.Entries<EntityDateTimeBase>().Where(e => e.State == EntityState.Modified).ToList();

            modifiefEntities.ForEach(e =>
            {
                e.Entity.ChangeAt = DateTime.Now;
            });
        }
    }
}