namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Finances.Domain;
    using Finances.Domain.Banking;

    public sealed class Configuration : DbMigrationsConfiguration<BankingDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(BankingDbContext context)
        {
            context.Banks.AddOrUpdate(
                p => p.Code,
                new BankEntity { Code = Guid.Parse("{1496DD29-14BF-4753-AACC-35203E3947B7}"), Name = "Bank Millennium", Country = "Pl", Swift = "Mille", Url = "http://www.bankmillennium.pl", ChangeAt = DateTime.Now },
                new BankEntity { Code = Guid.Parse("{740ED738-D34C-4918-9CD9-9EC280F3C093}"), Name = "Millennium BCP", Country = "Pt", Swift = "MillePt", Url = "http://www.millenniumbcp.pt", ChangeAt = DateTime.Now },
                new BankEntity { Code = Guid.Parse("F8C95B7D-A8EA-4FE6-95B5-930122E9A5A2"), Name = "Montepio Geral", Country = "Pt", Swift = "Montexx", Url = "http://www.montepio.pt", ChangeAt = DateTime.Now }
            );

            context.Currencies.AddOrUpdate(c => c.Code,
                new CurrencyEntity { Code = "Euro", ReasonToOneEuro = 0, ChangeAt = DateTime.Now },
                new CurrencyEntity { Code = "Pln", ReasonToOneEuro = 4.20m, ChangeAt = DateTime.Now }
            );
        }
    }
}