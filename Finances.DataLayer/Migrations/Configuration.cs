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
            var bankCaixaGuid = Guid.Parse("752ABB7E-FECE-4673-B561-690C56FC44D2");

            var bankMillenium = new BankEntity { Code = bankMilleniumGuid, Name = "Bank Millennium", Country = "Pl", Swift = "Mille", Url = "http://www.bankmillennium.pl" };
            var bankBcp = new BankEntity { Code = bankBcpGuid, Name = "Millennium BCP", Country = "Pt", Swift = "MillePt", Url = "http://www.millenniumbcp.pt" };
            var bankMontepio = new BankEntity { Code = bankMontepioGuid, Name = "Montepio Geral", Country = "Pt", Swift = "Montexx", Url = "http://www.montepio.pt" };
            var bankCaixa = new BankEntity { Code = bankCaixaGuid, Name = "Caixa Geral de Depositos", Country = "Pt", Swift = "caixa", Url = "http://www.cgd.pt" };

            var euro = new CurrencyEntity { CodeName = "Euro", ReasonToOneEuro = 0 };
            var pln = new CurrencyEntity { CodeName = "Pln", ReasonToOneEuro = 4.20m };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Country, p.Name, p.Swift, p.Url, p.ChangeAt },
                    bankMillenium,
                    bankBcp,
                    bankMontepio,
                    bankCaixa
                );

            context.SeedAddOrUpdate(p => p.CodeName, p => new { p.ReasonToOneEuro },
                euro,
                pln,
                new CurrencyEntity { CodeName = "Dolar", ReasonToOneEuro = 1.20m }
            );

            var goncaloGuid = Guid.Parse("9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B");
            var guiGuid = Guid.Parse("AF47E41B-344A-42AA-AEFF-07FE41E5D53C");
            var vascoGuid = Guid.Parse("C7EC913C-95A7-4BAC-9C2E-96A5E5B9C420");
            var isildaGuid = Guid.Parse("99B84DE3-2D7F-4D56-9592-092CEBA834B8");
            var filipaGuid = Guid.Parse("43E1428A-454B-4E6F-B83E-5E44BD28346D");

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
            var vascoPerson = new PersonEntity { Code = vascoGuid, Name = "Vasco", Surname = "Gaspar", Email = "vasco@mail.com", IsArchived = false, OwnerCode = goncaloGuid };
            var isildaPerson = new PersonEntity { Code = isildaGuid, Name = "Isilda", Surname = "Gaspar", Email = "zi@mail.com", IsArchived = false, OwnerCode = goncaloGuid };
            var filipaPerson = new PersonEntity { Code = filipaGuid, Name = "Filipa", Surname = "Viegas", Email = "filipa@mail.com", IsArchived = false, OwnerCode = goncaloGuid };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Name, p.Surname, p.Email, p.IsArchived, p.IsMe, p.ChangeAt },
                goncaloPerson,
                guilhermePerson,
                vascoPerson,
                isildaPerson,
                filipaPerson
            );

            var currentGoncalo = new CurrentAccountEntity
            {
                Code = Guid.Parse("303B2432-C710-4DD6-A034-17EB10793CEB"),
                Description = "Conta ordenado",
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
                Description = "Conta fun",
                Number = "121212",
                Iban = "Pt12233",
                Currency = euro,
                Amount = 500.51m,
                StartDate = DateTime.Today.AddYears(-2),
                Holder = guilhermePerson,
                Owner = goncaloPerson,
                Bank = bankMontepio
            };

            var currentVasco = new CurrentAccountEntity
            {
                Code = Guid.Parse("4F248CC3-73FC-47D8-B772-49EF64E35D4D"),
                Description = "Conta Corrente",
                Number = "121212",
                Iban = "Pt12233",
                Currency = euro,
                Amount = 0,
                StartDate = DateTime.Today.AddYears(-2),
                Holder = vascoPerson,
                Owner = goncaloPerson,
                Bank = bankCaixa
            };

            var currentFilipa = new CurrentAccountEntity
            {
                Code = Guid.Parse("DF756217-78C0-4877-BB7B-E210A88603C0"),
                Description = "Conta Corrente",
                Number = "123232323",
                Iban = "Pts3434343434",
                Currency = euro,
                Amount = 0m,
                StartDate = DateTime.Today.AddYears(-2),
                Holder = filipaPerson,
                Owner = goncaloPerson,
                Bank = bankBcp
            };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Description, p.Number, p.Iban, p.Amount, p.ChangeAt },
               currentGoncalo,
               currentGuilherme,
               currentVasco,
               currentFilipa
            );
        }
    }
}