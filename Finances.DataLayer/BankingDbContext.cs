// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankingDbContext.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The banking database context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
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

    /// <summary>
    /// The banking database context.
    /// </summary>
    public class BankingDbContext : DbContext
    {
        /// <summary>
        /// The Lock.
        /// </summary>
        private static readonly object Lock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="BankingDbContext"/> class.
        /// </summary>
        public BankingDbContext() : base( "BankingConnection" )
        {
            Database.SetInitializer<BankingDbContext>( null );
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;

            var ensureDllIsCopied = SqlProviderServices.Instance;

#if DEBUG
            this.Database.Log = s =>
                {
                    lock ( Lock )
                    {
                        try
                        {
                            string path = @"C:\Logs";
                            if ( !Directory.Exists( path ) )
                            {
                                Directory.CreateDirectory( path );
                            }

                            File.AppendAllText( $"{path}\\BankingLog.txt", s );
                        }
                        catch ( Exception )
                        {
                            // ignored
                        }
                    }
                };
#endif
        }

        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int SaveChanges()
        {
            this.SetCreatedDate();

            return base.SaveChanges();
        }

        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override Task<int> SaveChangesAsync()
        {
            this.SetCreatedDate();

            return base.SaveChangesAsync();
        }

        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override Task<int> SaveChangesAsync( CancellationToken cancellationToken )
        {
            this.SetCreatedDate();

            return base.SaveChangesAsync( cancellationToken );
        }

        /// <summary>
        /// Gets or sets the cards.
        /// </summary>
        public DbSet<CardEntity> Cards { get; set; }

        /// <summary>
        /// Gets or sets the banks.
        /// </summary>
        public DbSet<BankEntity> Banks { get; set; }

        /// <summary>
        /// Gets or sets the currencies.
        /// </summary>
        public DbSet<CurrencyEntity> Currencies { get; set; }

        /// <summary>
        /// Gets or sets the currency history.
        /// </summary>
        public DbSet<CurrencyHistoryEntity> CurrencyHistory { get; set; }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        public DbSet<PersonEntity> Persons { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        public DbSet<AccountEntity> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the parameterizations.
        /// </summary>
        public DbSet<ParameterizationEntity> Parameterizations { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add( new DataTypePropertyAttributeConvention() );
            modelBuilder.Conventions.Add( new DecimalPrecisionAttributeConvention() );
            modelBuilder.Configurations.AddFromAssembly( this.GetType().Assembly );
            base.OnModelCreating( modelBuilder );
        }

        /// <summary>
        /// The set created date.
        /// </summary>
        private void SetCreatedDate()
        {
            var addedEntities = this.ChangeTracker.Entries<EntityDateTimeBase>().Where( e => e.State == EntityState.Added ).ToList();

            addedEntities.ForEach( e =>
             {
                 e.Entity.CreatedAt = DateTime.Now;
                 e.Entity.ChangeAt = DateTime.Now;
             } );

            var modifiefEntities = this.ChangeTracker.Entries<EntityDateTimeBase>().Where( e => e.State == EntityState.Modified ).ToList();

            modifiefEntities.ForEach( e =>
             {
                 e.Entity.ChangeAt = DateTime.Now;
             } );
        }
    }
}