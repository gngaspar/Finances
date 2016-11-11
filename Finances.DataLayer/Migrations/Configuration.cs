namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using Finances.Contract.Common;
    using Finances.DataLayer.Extension;
    using Finances.Domain.Accounting;
    using Finances.Domain.Banking;
    using Finances.Domain.Human;
    using Finances.Domain.Plastic;

    public sealed class Configuration : DbMigrationsConfiguration<BankingDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(BankingDbContext context)
        {
            var format = "dd/MM/yyyy";
            var provider = CultureInfo.InvariantCulture;

            var bankMilleniumGuid = Guid.Parse("{1496DD29-14BF-4753-AACC-35203E3947B7}");
            var bankBcpGuid = Guid.Parse("{740ED738-D34C-4918-9CD9-9EC280F3C093}");
            var bankMontepioGuid = Guid.Parse("F8C95B7D-A8EA-4FE6-95B5-930122E9A5A2");
            var bankCaixaGuid = Guid.Parse("752ABB7E-FECE-4673-B561-690C56FC44D2");

            var bankMillenium = new BankEntity { Code = bankMilleniumGuid, Name = "Bank Millennium", Country = "Pl", Swift = "BIGBPLPW", Url = "http://www.bankmillennium.pl" };
            var bankBcp = new BankEntity { Code = bankBcpGuid, Name = "Millennium BCP", Country = "Pt", Swift = "MillePt", Url = "http://www.millenniumbcp.pt" };
            var bankMontepio = new BankEntity { Code = bankMontepioGuid, Name = "Montepio Geral", Country = "Pt", Swift = "MPIOPTPL", Url = "http://www.montepio.pt" };
            var bankCaixa = new BankEntity { Code = bankCaixaGuid, Name = "Caixa Geral de Depositos", Country = "Pt", Swift = "caixa", Url = "http://www.cgd.pt" };

            var euro = new CurrencyEntity { Currency = "Eur", Name = "Euro", ReasonToOneEuro = 0 };
            var pln = new CurrencyEntity { Currency = "Pln", Name = "Zloty", ReasonToOneEuro = 4.20m };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Country, p.Name, p.Swift, p.Url, p.ChangeAt },
                    bankMillenium,
                    bankBcp,
                    bankMontepio,
                    bankCaixa
                );

            context.SaveChanges();

            context.SeedAddOrUpdate(p => p.Currency, p => new { p.ReasonToOneEuro },
                euro,
                pln,
                new CurrencyEntity { Currency = "USD", Name = "Dollar", ReasonToOneEuro = 1.20m }
            );

            context.SaveChanges();

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

            context.SaveChanges();

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

            context.SaveChanges();

            var currentGoncaloGuid = Guid.Parse("303B2432-C710-4DD6-A034-17EB10793CEB");

            var currentGoncalo = new CurrentAccountEntity
            {
                Code = currentGoncaloGuid,
                Description = "Conta ordenado",
                Number = "029.10.012311-5",
                Iban = "PT50.0036.0029.99100123115.13",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 462.52m,
                StartDate = DateTime.ParseExact("01/02/2008", format, provider),
                Holder = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMontepioGuid)
            };

            var currentPlGoncalo = new CurrentAccountEntity
            {
                Code = Guid.Parse("28244669-e675-4f28-bfeb-3074eb556c40"),
                Description = "Conta Polonia",
                Number = "0247914561",
                Iban = "PL92.1160.2202.00000002479145.61",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "PLN"),
                Amount = 1000.55m,
                StartDate = DateTime.ParseExact("04/10/2013", format, provider),
                Holder = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMilleniumGuid)
            };

            var currentPlEuroGoncalo = new CurrentAccountEntity
            {
                Code = Guid.Parse("BFC9DF65-8650-4925-AEFF-31BC2062C357"),
                Description = "Conta Polonia Euros",
                Number = "0248923401",
                Iban = "PL79.1160.2202.00000002489234.01",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 0m,
                StartDate = DateTime.ParseExact("21/10/2013", format, provider),
                Holder = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMilleniumGuid)
            };

            var currentGuiGuid = Guid.Parse("9D73C73A-7E1F-40A9-A52E-460010566B4F");

            var currentGuilherme = new CurrentAccountEntity
            {
                Code = currentGuiGuid,
                Description = "Conta fun",
                Number = "029.10.013309-8",
                Iban = "PT50.0036.0029.99100133098.37",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 707.93m,
                StartDate = DateTime.ParseExact("01/01/2015", format, provider),
                Holder = context.Persons.SingleOrDefault(i => i.Code == guiGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMontepioGuid)
            };

            var currentVasco = new CurrentAccountEntity
            {
                Code = Guid.Parse("4F248CC3-73FC-47D8-B772-49EF64E35D4D"),
                Description = "Conta Corrente",
                Number = "63566423095",
                Iban = "PT50.0035.0995.00635664230.95",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 0,
                StartDate = DateTime.Today.AddYears(-2),
                Holder = context.Persons.SingleOrDefault(i => i.Code == vascoGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankCaixaGuid)
            };

            var currentFilipa = new CurrentAccountEntity
            {
                Code = Guid.Parse("DF756217-78C0-4877-BB7B-E210A88603C0"),
                Description = "Conta Corrente",
                Number = "4956598449",
                Iban = "PT50.0033.0000.00049565984.49",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 0m,
                StartDate = DateTime.Today.AddYears(-2),
                Holder = context.Persons.SingleOrDefault(i => i.Code == filipaGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankBcpGuid)
            };

            var loanGoncalo = new LoanAccountEntity
            {
                Code = Guid.Parse("f03f8057-e33e-4ebd-8b50-7005d8bd2188"),
                Description = "Conta Casa",
                Number = "029.21.100472-5",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 47580.38m,
                StartDate = DateTime.ParseExact("23/07/2008", format, provider),
                Holder = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMontepioGuid),
                InicialAmount = 70000,
                PremiumPercentage = 0,
                InterestNetRate = 0.189m,
                LoanEndDate = DateTime.ParseExact("28/07/2033", format, provider),
                LoanInterestRate = 5.441m,
                LoanRelatedAccount = currentGoncalo
            };

            var loan2Goncalo = new LoanAccountEntity
            {
                Code = Guid.Parse("5e919e86-0d5a-4eca-b805-0a22471443cb"),
                Description = "Conta Carro",
                Number = "029.27.100168-6",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 23618.64m,
                StartDate = DateTime.ParseExact("16/07/2010", format, provider),
                Holder = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMontepioGuid),
                InicialAmount = 38500,
                PremiumPercentage = 0,
                InterestNetRate = 3.298m,
                LoanEndDate = DateTime.ParseExact("16/07/2033", format, provider),
                LoanInterestRate = 4.328m,
                LoanRelatedAccount = currentGoncalo
            };

            var savingGoncalo = new SavingAccountEntity
            {
                Code = Guid.Parse("ec7bdd2c-a3fe-42f0-9e91-b2e4333b9ae9"),
                Description = "Poupanca Activa",
                Number = "732.15.420299-6",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 1058.38m,
                StartDate = DateTime.ParseExact("03/08/2016", format, provider),
                Holder = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMontepioGuid),
                AutomaticRenovation = AutomaticRenovation.No,
                InterestCapitalization = true,
                InterestPayment = InterestPayment.Anual,
                SavingEndDate = DateTime.ParseExact("03/08/2017", format, provider),
                SavingInterestRate = 0.8m,
                SavingRelatedAccount = currentGoncalo
            };

            var savingGui = new SavingAccountEntity
            {
                Code = Guid.Parse("AA111116-70F2-47CC-9C21-01A161D10D92"),
                Description = "Poupanca Bue",
                Number = "732.15.417187-8",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 400.00m,
                StartDate = DateTime.ParseExact("08/07/2015", format, provider),
                Holder = context.Persons.SingleOrDefault(i => i.Code == guiGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMontepioGuid),
                AutomaticRenovation = AutomaticRenovation.YesSamePeriod,
                InterestCapitalization = false,
                InterestPayment = InterestPayment.Anual,
                SavingEndDate = DateTime.ParseExact("08/07/2016", format, provider),
                SavingInterestRate = 1.0m,
                SavingRelatedAccount = currentGuilherme
            };

            var saving2Gui = new SavingAccountEntity
            {
                Code = Guid.Parse("7D2E570A-BBC3-41D6-B2E3-B47BB491D60C"),
                Description = "Poupanca Bue",
                Number = "732.15.430705-0",
                Currency = context.Currencies.SingleOrDefault(i => i.Currency == "EUR"),
                Amount = 250.00m,
                StartDate = DateTime.ParseExact("13/11/2015", format, provider),
                Holder = context.Persons.SingleOrDefault(i => i.Code == guiGuid),
                Owner = context.Persons.SingleOrDefault(i => i.Code == goncaloGuid),
                Bank = context.Banks.SingleOrDefault(i => i.Code == bankMontepioGuid),
                AutomaticRenovation = AutomaticRenovation.YesSamePeriod,
                InterestCapitalization = false,
                InterestPayment = InterestPayment.Anual,
                SavingEndDate = DateTime.ParseExact("13/11/2017", format, provider),
                SavingInterestRate = 1.0m,
                SavingRelatedAccount = currentGuilherme
            };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Description, p.Number, p.Iban, p.Amount, p.ChangeAt },
               currentGoncalo,
               currentGuilherme,
               currentVasco,
               currentFilipa,
               currentPlGoncalo,
               currentPlEuroGoncalo
            );

            context.SaveChanges();

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Description, p.Number, p.Amount, p.ChangeAt, p.InicialAmount, p.InterestNetRate, p.LoanEndDate, p.LoanInterestRate, p.PremiumPercentage, p.LoanRelatedAccount },
               loanGoncalo,
               loan2Goncalo
            );

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Description, p.Number, p.Amount, p.ChangeAt, p.InterestCapitalization, p.SavingEndDate, p.SavingInterestRate, p.SavingRelatedAccount },
               savingGoncalo,
               savingGui,
               saving2Gui
            );

            context.SaveChanges();

            var visa = new CreditCardEntity
            {
                Code = Guid.Parse("951C4C66-EA1C-4285-B122-308CDF0243D5"),
                CardNumber = "5731",
                CardProvider = CardProvider.Visa,
                Description = "Visa Cinza",
                PaymentDay = 7,
                Limit = 1000,
                UsedLimit = 300,
                Expire = DateTime.ParseExact("31/01/2020", format, provider),
                Account = currentGoncalo,
                Bank = bankMontepio,
                Currency = euro,
                Holder = goncaloPerson,
                Owner = goncaloPerson
            };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Description, p.Code, p.CardNumber, p.PaymentDay, p.Limit, p.UsedLimit, p.Expire, p.Account, p.Bank, p.Currency, p.Holder, p.Owner, p.ChangeAt },
               visa
            );

            var currentMontepio = new DebitCardEntity
            {
                Code = Guid.Parse("B22056AC-91FD-4769-9056-E235F2757A43"),
                CardNumber = "5594",
                CardProvider = CardProvider.VisaElectron,
                Description = "Debito Amarelo",
                Expire = DateTime.ParseExact("30/09/2019", format, provider),
                Account = currentGoncalo,
                Bank = bankMontepio,
                Currency = euro,
                Holder = goncaloPerson,
                Owner = goncaloPerson
            };

            var currentMille = new DebitCardEntity
            {
                Code = Guid.Parse("1C3E3692-1AD9-401D-B4AA-C06A31967A95"),
                CardNumber = "5505",
                CardProvider = CardProvider.Visa,
                Description = "Debito Cinza",
                Expire = DateTime.ParseExact("30/09/2019", format, provider),
                Account = currentPlGoncalo,
                Bank = bankMillenium,
                Currency = pln,
                Holder = goncaloPerson,
                Owner = goncaloPerson
            };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Description, p.Code, p.CardNumber, p.Expire, p.Account, p.Bank, p.Currency, p.Holder, p.Owner, p.ChangeAt },
               currentMontepio,
               currentMille
            );

            var preMille = new PrePaidCardEntity
            {
                Code = Guid.Parse("283FBB3A-B988-42A7-95F6-8A377D0C9CC1"),
                CardNumber = "9102",
                CardProvider = CardProvider.Maestro,
                Description = "PrePago Preto",
                Expire = DateTime.ParseExact("31/05/2019", format, provider),
                Account = currentPlGoncalo,
                Bank = bankMillenium,
                Currency = pln,
                Holder = goncaloPerson,
                Owner = goncaloPerson,
                AvailableAmount = 500,
                MaximumAmount = 500
            };

            var preMontepio = new PrePaidCardEntity
            {
                Code = Guid.Parse("905FADBF-F44D-4DFC-850D-0368DA41CF58"),
                CardNumber = "5555",
                CardProvider = CardProvider.VisaElectron,
                Description = "PrePago Mae",
                Expire = DateTime.ParseExact("31/05/2019", format, provider),
                Account = currentGoncalo,
                Bank = bankMontepio,
                Currency = euro,
                Holder = isildaPerson,
                Owner = goncaloPerson,
                AvailableAmount = 50,
                MaximumAmount = 1500
            };

            context.SeedAddOrUpdate(p => p.Code, p => new { p.Description, p.Code, p.CardNumber, p.AvailableAmount, p.MaximumAmount, p.Expire, p.Account, p.Bank, p.Currency, p.Holder, p.Owner, p.ChangeAt },
               preMontepio,
               preMille
            );

            context.SaveChanges();
        }
    }
}