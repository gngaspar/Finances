namespace Finances.DataLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Inicial : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.Parameterizations", "ToCard_Code", "dbo.Cards");
            DropForeignKey("dbo.Parameterizations", "ToAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Parameterizations", "Parent_Code", "dbo.Parameterizations");
            DropForeignKey("dbo.Parameterizations", "Owner_Code", "dbo.Persons");
            DropForeignKey("dbo.Parameterizations", "FromAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Parameterizations", "Currency_Currency", "dbo.Currencies");
            DropForeignKey("dbo.Cards", "Owner_Code", "dbo.Persons");
            DropForeignKey("dbo.Cards", "Holder_Code", "dbo.Persons");
            DropForeignKey("dbo.Cards", "Currency_Currency", "dbo.Currencies");
            DropForeignKey("dbo.Cards", "Bank_Code", "dbo.Banks");
            DropForeignKey("dbo.Cards", "Account_Code", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "SavingRelatedAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "LoanRelatedAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Owner_Code", "dbo.Persons");
            DropForeignKey("dbo.Accounts", "Holder_Code", "dbo.Persons");
            DropForeignKey("dbo.Accounts", "Currency_Currency", "dbo.Currencies");
            DropForeignKey("dbo.Accounts", "Bank_Code", "dbo.Banks");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Parameterizations", new[] { "ToCard_Code" });
            DropIndex("dbo.Parameterizations", new[] { "ToAccount_Code" });
            DropIndex("dbo.Parameterizations", new[] { "Parent_Code" });
            DropIndex("dbo.Parameterizations", new[] { "Owner_Code" });
            DropIndex("dbo.Parameterizations", new[] { "FromAccount_Code" });
            DropIndex("dbo.Parameterizations", new[] { "Currency_Currency" });
            DropIndex("dbo.Cards", new[] { "Owner_Code" });
            DropIndex("dbo.Cards", new[] { "Holder_Code" });
            DropIndex("dbo.Cards", new[] { "Currency_Currency" });
            DropIndex("dbo.Cards", new[] { "Bank_Code" });
            DropIndex("dbo.Cards", new[] { "Account_Code" });
            DropIndex("dbo.Banks", new[] { "Swift" });
            DropIndex("dbo.Accounts", new[] { "SavingRelatedAccount_Code" });
            DropIndex("dbo.Accounts", new[] { "LoanRelatedAccount_Code" });
            DropIndex("dbo.Accounts", new[] { "Owner_Code" });
            DropIndex("dbo.Accounts", new[] { "Holder_Code" });
            DropIndex("dbo.Accounts", new[] { "Currency_Currency" });
            DropIndex("dbo.Accounts", new[] { "Bank_Code" });
            DropTable("dbo.Users");
            DropTable("dbo.Parameterizations");
            DropTable("dbo.Cards");
            DropTable("dbo.Persons");
            DropTable("dbo.Currencies");
            DropTable("dbo.Banks");
            DropTable("dbo.Accounts");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                {
                    Code = c.Guid(nullable: false),
                    Number = c.String(nullable: false, maxLength: 100),
                    Description = c.String(nullable: false, maxLength: 100),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    StartDate = c.DateTime(nullable: false, storeType: "date"),
                    ChangeAt = c.DateTime(),
                    CreatedAt = c.DateTime(),
                    Iban = c.String(maxLength: 100),
                    InicialAmount = c.Decimal(precision: 18, scale: 2),
                    InterestNetRate = c.Decimal(precision: 18, scale: 3),
                    LoanEndDate = c.DateTime(storeType: "date"),
                    LoanInterestRate = c.Decimal(precision: 18, scale: 3),
                    PremiumPercentage = c.Decimal(precision: 18, scale: 3),
                    InterestCapitalization = c.Boolean(),
                    SavingEndDate = c.DateTime(storeType: "date"),
                    SavingInterestRate = c.Decimal(precision: 18, scale: 3),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                    Bank_Code = c.Guid(nullable: false),
                    Currency_Currency = c.String(nullable: false, maxLength: 3),
                    Holder_Code = c.Guid(),
                    Owner_Code = c.Guid(nullable: false),
                    LoanRelatedAccount_Code = c.Guid(),
                    SavingRelatedAccount_Code = c.Guid(),
                })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Banks", t => t.Bank_Code, cascadeDelete: false)
                .ForeignKey("dbo.Currencies", t => t.Currency_Currency, cascadeDelete: false)
                .ForeignKey("dbo.Persons", t => t.Holder_Code)
                .ForeignKey("dbo.Persons", t => t.Owner_Code, cascadeDelete: false)
                .ForeignKey("dbo.Accounts", t => t.LoanRelatedAccount_Code)
                .ForeignKey("dbo.Accounts", t => t.SavingRelatedAccount_Code)
                .Index(t => t.Bank_Code)
                .Index(t => t.Currency_Currency)
                .Index(t => t.Holder_Code)
                .Index(t => t.Owner_Code)
                .Index(t => t.LoanRelatedAccount_Code)
                .Index(t => t.SavingRelatedAccount_Code);

            CreateTable(
                "dbo.Banks",
                c => new
                {
                    Code = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 100),
                    Country = c.String(nullable: false, maxLength: 5),
                    Swift = c.String(nullable: false, maxLength: 50),
                    Url = c.String(maxLength: 250),
                    ChangeAt = c.DateTime(),
                    CreatedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Code)
                .Index(t => t.Swift, unique: true);

            CreateTable(
                "dbo.Currencies",
                c => new
                {
                    Currency = c.String(nullable: false, maxLength: 3),
                    Name = c.String(nullable: false, maxLength: 50),
                    ReasonToOneEuro = c.Decimal(nullable: false, precision: 12, scale: 2),
                    ChangeAt = c.DateTime(),
                    CreatedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Currency);

            CreateTable(
                "dbo.Persons",
                c => new
                {
                    Code = c.Guid(nullable: false),
                    OwnerCode = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 200),
                    Surname = c.String(nullable: false, maxLength: 200),
                    Email = c.String(maxLength: 200),
                    IsArchived = c.Boolean(nullable: false),
                    ChangeAt = c.DateTime(),
                    CreatedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Code);

            CreateTable(
                "dbo.Cards",
                c => new
                {
                    Code = c.Guid(nullable: false),
                    CardNumber = c.String(nullable: false, maxLength: 4),
                    Description = c.String(nullable: false, maxLength: 100),
                    Expire = c.DateTime(nullable: false, storeType: "date"),
                    ChangeAt = c.DateTime(),
                    CreatedAt = c.DateTime(),
                    Limit = c.Decimal(precision: 18, scale: 2),
                    PaymentDay = c.Int(),
                    UsedLimit = c.Decimal(precision: 18, scale: 2),
                    AvailableAmount = c.Decimal(precision: 18, scale: 2),
                    MaximumAmount = c.Decimal(precision: 18, scale: 2),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                    Account_Code = c.Guid(nullable: false),
                    Bank_Code = c.Guid(nullable: false),
                    Currency_Currency = c.String(nullable: false, maxLength: 3),
                    Holder_Code = c.Guid(nullable: false),
                    Owner_Code = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Accounts", t => t.Account_Code, cascadeDelete: false)
                .ForeignKey("dbo.Banks", t => t.Bank_Code, cascadeDelete: false)
                .ForeignKey("dbo.Currencies", t => t.Currency_Currency, cascadeDelete: false)
                .ForeignKey("dbo.Persons", t => t.Holder_Code, cascadeDelete: false)
                .ForeignKey("dbo.Persons", t => t.Owner_Code, cascadeDelete: false)
                .Index(t => t.Account_Code)
                .Index(t => t.Bank_Code)
                .Index(t => t.Currency_Currency)
                .Index(t => t.Holder_Code)
                .Index(t => t.Owner_Code);

            CreateTable(
                "dbo.Parameterizations",
                c => new
                {
                    Code = c.Guid(nullable: false),
                    Description = c.String(nullable: false, maxLength: 100),
                    Amount = c.Decimal(nullable: false, precision: 12, scale: 2),
                    Active = c.Boolean(nullable: false),
                    SpecificDay = c.DateTime(storeType: "date"),
                    Day = c.Int(),
                    ChangeAt = c.DateTime(),
                    CreatedAt = c.DateTime(),
                    Currency_Currency = c.String(maxLength: 3),
                    FromAccount_Code = c.Guid(),
                    Owner_Code = c.Guid(nullable: false),
                    Parent_Code = c.Guid(),
                    ToAccount_Code = c.Guid(),
                    ToCard_Code = c.Guid(),
                })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Currencies", t => t.Currency_Currency)
                .ForeignKey("dbo.Accounts", t => t.FromAccount_Code)
                .ForeignKey("dbo.Persons", t => t.Owner_Code, cascadeDelete: false)
                .ForeignKey("dbo.Parameterizations", t => t.Parent_Code)
                .ForeignKey("dbo.Accounts", t => t.ToAccount_Code)
                .ForeignKey("dbo.Cards", t => t.ToCard_Code)
                .Index(t => t.Currency_Currency)
                .Index(t => t.FromAccount_Code)
                .Index(t => t.Owner_Code)
                .Index(t => t.Parent_Code)
                .Index(t => t.ToAccount_Code)
                .Index(t => t.ToCard_Code);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Code = c.Guid(nullable: false),
                    Email = c.String(nullable: false, maxLength: 200),
                    Name = c.String(nullable: false, maxLength: 200),
                    Surname = c.String(nullable: false, maxLength: 200),
                    IdNumber = c.String(maxLength: 25),
                    IdNumberExpirationDate = c.DateTime(nullable: false, storeType: "date"),
                    Passport = c.String(maxLength: 25),
                    PassportExpirationDate = c.DateTime(nullable: false, storeType: "date"),
                    Nif = c.String(maxLength: 25),
                    HealthCare = c.String(maxLength: 25),
                    HealthCareExpirationDate = c.DateTime(nullable: false),
                    SocialSecurity = c.String(maxLength: 25),
                    ChangeAt = c.DateTime(),
                    CreatedAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Code)
                .Index(t => t.Email, unique: true);
        }
    }
}