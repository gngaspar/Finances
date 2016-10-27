namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Finances.DataLayer.Extension;
    using Finances.Domain;
    using Finances.Domain.Banking;
    using Finances.Domain.Human;

    public sealed class Configuration : DbMigrationsConfiguration<BankingDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(BankingDbContext context)
        {
            var bankMilleniumGuid = Guid.Parse("{1496DD29-14BF-4753-AACC-35203E3947B7}");
            var bankBcpGuid = Guid.Parse("{740ED738-D34C-4918-9CD9-9EC280F3C093}");
            var bankMontepioGuid = Guid.Parse("F8C95B7D-A8EA-4FE6-95B5-930122E9A5A2");

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Country, p.Name, p.Swift, p.Url, p.ChangeAt },
                    new BankEntity { Code = bankMilleniumGuid, Name = "Bank Millennium", Country = "Pl", Swift = "Mille", Url = "http://www.bankmillennium.pl" },
                    new BankEntity { Code = bankBcpGuid, Name = "Millennium BCP", Country = "Pt", Swift = "MillePt", Url = "http://www.millenniumbcp.pt" },
                    new BankEntity { Code = bankMontepioGuid, Name = "Montepio Geral", Country = "Pt", Swift = "Montexx", Url = "http://www.montepio.pt" }
                );

            context.SeedAddOrUpdate(p => p.CodeName, p => new { p.ReasonToOneEuro },
                new CurrencyEntity { CodeName = "Euro", ReasonToOneEuro = 0 },
                new CurrencyEntity { CodeName = "Pln", ReasonToOneEuro = 4.20m },
                new CurrencyEntity { CodeName = "Dolar", ReasonToOneEuro = 1.20m }
            );

            var goncaloGuid = Guid.Parse("9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B");
            var guiGuid = Guid.Parse("AF47E41B-344A-42AA-AEFF-07FE41E5D53C");

            var goncaloUser = new UserEntity
            {
                Code = goncaloGuid,
                Name = "Goncalo",
                Surname = "Gaspar",
                Email = "ggaspar@mail.com",
                IdNumber = "xxxxx",
                IdNumberExpirationDate = DateTime.Today.AddYears(2),
                Nif = "xxxYYyyyx",
                HealthCare = "xxxxx",
                HealthCareExpirationDate = DateTime.Today.AddMonths(-5).AddDays(5),
                SocialSecurity = "xxxxxx",
            };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Name, p.Surname, p.Email, p.IdNumber, p.IdNumberExpirationDate, p.Passport, p.PassportExpirationDate, p.Nif, p.HealthCare, p.HealthCareExpirationDate, p.SocialSecurity, p.ChangeAt },
                goncaloUser
            );

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Name, p.Surname, p.Email, p.IsArchived, p.IsMe, p.ChangeAt },
                new PersonEntity
                {
                    Code = goncaloGuid,
                    Name = "Goncalo",
                    Surname = "Gaspar",
                    Email = "ggaspar@mail.com",
                    IsArchived = false,
                    OwnerCode = goncaloGuid
                },
                new PersonEntity
                {
                    Code = guiGuid,
                    Name = "Guilherme",
                    Surname = "Gaspar",
                    Email = "guigaspar@mail.com",
                    IsArchived = false,
                    OwnerCode = goncaloGuid
                }

            );
        }
    }
}