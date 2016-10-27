namespace Finances.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Finances.Domain;
    using Finances.Domain.Banking;
    using Finances.Domain.Human;

    public class BankingDbContext : DbContext
    {
        private static readonly object _lock = new object();

        public BankingDbContext()
            : base( "BankingConnection" )
        {
            Database.SetInitializer<BankingDbContext>( null );
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;

            var ensureDllIsCopied = SqlProviderServices.Instance;

#if DEBUG
            this.Database.Log = s =>
                {
                    lock ( _lock )
                    {
                        File.AppendAllText( @"C:/DBLog.txt", s );
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

        public override Task<int> SaveChangesAsync( CancellationToken cancellationToken )
        {
            this.SetCreatedDate();

            return base.SaveChangesAsync( cancellationToken );
        }

        public DbSet<BankEntity> Banks { get; set; }

        public DbSet<CurrencyEntity> Currencies { get; set; }

        public DbSet<PersonEntity> Persons { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Conventions.Add( new DataTypePropertyAttributeConvention() );
            modelBuilder.Configurations.AddFromAssembly( this.GetType().Assembly );
            base.OnModelCreating( modelBuilder );
        }

        private void SetCreatedDate()
        {
            var addedEntities = this.ChangeTracker.Entries<EntityDateTimeBase>().Where(e => e.State == EntityState.Added).ToList();

            addedEntities.ForEach(e =>
            {
                e.Entity.CreatedAt = DateTime.Now;
                e.Entity.ChangeAt = DateTime.Now;
            });
        }
    }
}