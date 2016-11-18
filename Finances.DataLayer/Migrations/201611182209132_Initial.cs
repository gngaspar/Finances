namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
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
                        Currency = c.String(nullable: false, maxLength: 3),
                        Holder = c.Guid(nullable: false),
                        Bank = c.Guid(nullable: false),
                        Owner = c.Guid(nullable: false),
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
                        LoanRelatedAccount_Code = c.Guid(),
                        SavingRelatedAccount_Code = c.Guid(),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Accounts", t => t.LoanRelatedAccount_Code)
                .ForeignKey("dbo.Accounts", t => t.SavingRelatedAccount_Code)
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
                "dbo.Cards",
                c => new
                    {
                        Code = c.Guid(nullable: false),
                        CardNumber = c.String(nullable: false, maxLength: 4),
                        Description = c.String(nullable: false, maxLength: 100),
                        Expire = c.DateTime(nullable: false, storeType: "date"),
                        Currency = c.String(nullable: false, maxLength: 3),
                        ChangeAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        Holder = c.Guid(nullable: false),
                        Bank = c.Guid(nullable: false),
                        Owner = c.Guid(nullable: false),
                        Limit = c.Decimal(precision: 18, scale: 2),
                        PaymentDay = c.Int(),
                        UsedLimit = c.Decimal(precision: 18, scale: 2),
                        AvailableAmount = c.Decimal(precision: 18, scale: 2),
                        MaximumAmount = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Account_Code = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Accounts", t => t.Account_Code, cascadeDelete: true)
                .Index(t => t.Account_Code);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Currency = c.String(nullable: false, maxLength: 3),
                        Name = c.String(nullable: false, maxLength: 50),
                        Order = c.Int(nullable: false),
                        ReasonToOneEuro = c.Decimal(nullable: false, precision: 12, scale: 5),
                        ChangeAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Currency);
            
            CreateTable(
                "dbo.CurrencyHistory",
                c => new
                    {
                        Currency = c.String(nullable: false, maxLength: 3),
                        CreatedAtDay = c.DateTime(nullable: false, storeType: "date"),
                        ReasonToOneEuro = c.Decimal(nullable: false, precision: 12, scale: 5),
                    })
                .PrimaryKey(t => new { t.Currency, t.CreatedAtDay });
            
            CreateTable(
                "dbo.Parameterizations",
                c => new
                    {
                        Code = c.Guid(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        Amount = c.Decimal(nullable: false, precision: 12, scale: 2),
                        Active = c.Boolean(nullable: false),
                        Currency = c.String(nullable: false, maxLength: 3),
                        SpecificDay = c.DateTime(storeType: "date"),
                        Day = c.Int(),
                        ChangeAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        Owner = c.Guid(nullable: false),
                        FromAccount_Code = c.Guid(),
                        Parent_Code = c.Guid(),
                        ToAccount_Code = c.Guid(),
                        ToCard_Code = c.Guid(),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Accounts", t => t.FromAccount_Code)
                .ForeignKey("dbo.Parameterizations", t => t.Parent_Code)
                .ForeignKey("dbo.Accounts", t => t.ToAccount_Code)
                .ForeignKey("dbo.Cards", t => t.ToCard_Code)
                .Index(t => t.FromAccount_Code)
                .Index(t => t.Parent_Code)
                .Index(t => t.ToAccount_Code)
                .Index(t => t.ToCard_Code);
            
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
        
        public override void Down()
        {
            DropForeignKey("dbo.Parameterizations", "ToCard_Code", "dbo.Cards");
            DropForeignKey("dbo.Parameterizations", "ToAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Parameterizations", "Parent_Code", "dbo.Parameterizations");
            DropForeignKey("dbo.Parameterizations", "FromAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Cards", "Account_Code", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "SavingRelatedAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "LoanRelatedAccount_Code", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Parameterizations", new[] { "ToCard_Code" });
            DropIndex("dbo.Parameterizations", new[] { "ToAccount_Code" });
            DropIndex("dbo.Parameterizations", new[] { "Parent_Code" });
            DropIndex("dbo.Parameterizations", new[] { "FromAccount_Code" });
            DropIndex("dbo.Cards", new[] { "Account_Code" });
            DropIndex("dbo.Banks", new[] { "Swift" });
            DropIndex("dbo.Accounts", new[] { "SavingRelatedAccount_Code" });
            DropIndex("dbo.Accounts", new[] { "LoanRelatedAccount_Code" });
            DropTable("dbo.Users");
            DropTable("dbo.Persons");
            DropTable("dbo.Parameterizations");
            DropTable("dbo.CurrencyHistory");
            DropTable("dbo.Currencies");
            DropTable("dbo.Cards");
            DropTable("dbo.Banks");
            DropTable("dbo.Accounts");
        }
    }
}
