namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

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


            var bankMillenium = new BankEntity { Code = bankMilleniumGuid, Name = "Bank Millennium", Country = "Pl", Swift = "Mille", Url = "http://www.bankmillennium.pl" };
            var bankBcp = new BankEntity { Code = bankBcpGuid, Name = "Millennium BCP", Country = "Pt", Swift = "MillePt", Url = "http://www.millenniumbcp.pt" };
            var bankMontepio = new BankEntity { Code = bankMontepioGuid, Name = "Montepio Geral", Country = "Pt", Swift = "Montexx", Url = "http://www.montepio.pt" };

            var euro = new CurrencyEntity { CodeName = "Euro", ReasonToOneEuro = 0 };
            var pln = new CurrencyEntity { CodeName = "Pln", ReasonToOneEuro = 4.20m };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Country, p.Name, p.Swift, p.Url, p.ChangeAt },
                    bankMillenium,
                    bankBcp,
                    bankMontepio
                );

            context.SeedAddOrUpdate(p => p.CodeName, p => new { p.ReasonToOneEuro },
                euro,
                pln,
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

            var goncaloPerson = new PersonEntity { Code = goncaloGuid, Name = "Goncalo", Surname = "Gaspar", Email = "ggaspar@mail.com", IsArchived = false, OwnerCode = goncaloGuid };
            var guilhermePerson = new PersonEntity { Code = guiGuid, Name = "Guilherme", Surname = "Gaspar", Email = "guigaspar@mail.com", IsArchived = false, OwnerCode = goncaloGuid };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Name, p.Surname, p.Email, p.IsArchived, p.IsMe, p.ChangeAt },
                goncaloPerson,
                guilhermePerson
            );

            var currentGoncalo = new CurrentAccountEntity
            {
                Code = Guid.Parse("303B2432-C710-4DD6-A034-17EB10793CEB"),
                Description = "Conta ordenado part 2",
                Number = "1212",
                Iban = "Pt12",
                Currency = euro,
                Amount = 1000.55m,
                StartDate = DateTime.Today.AddYears(-5),
                Holder = goncaloPerson,
                Owner = goncaloPerson,
                Bank = bankMontepio
            };

            var currentGuilherme = new CurrentAccountEntity
            {
                Code = Guid.Parse("9D73C73A-7E1F-40A9-A52E-460010566B4F"),
                Description = "Conta fun lol",
                Number = "121212",
                Iban = "Pt12233",
                Currency = context.Currencies.SingleOrDefault(i => i.CodeName == "Euro"),
                Amount = 500.51m,
                StartDate = DateTime.Today.AddYears(-2),
                Holder = context.Persons.SingleOrDefault(i => i.Code == guiGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMontepioGuid)
            };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Description, p.Number, p.Iban, p.Amount, p.ChangeAt },
               currentGoncalo,
               currentGuilherme
            );
        }
    }
}