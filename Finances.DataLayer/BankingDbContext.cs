using System.Configuration;
using Finances.DataLayer.Configurations;

namespace Finances.DataLayer
{
    using System.Data.Entity;
    using Finances.Domain.Banking;
    public class BankingDbContext : DbContext
    {
        public BankingDbContext()
            : base("BankingConnection")
        {

        }

        public DbSet<BankEntity> Banks
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BankEntityConfiguration());
        }
    }


}
