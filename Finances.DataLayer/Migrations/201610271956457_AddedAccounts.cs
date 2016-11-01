namespace Finances.DataLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedAccounts : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "SavingRelatedAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "LoanRelatedAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Owner_Code", "dbo.Persons");
            DropForeignKey("dbo.Accounts", "Holder_Code", "dbo.Persons");
            DropForeignKey("dbo.Accounts", "Currency_CodeName", "dbo.Currencies");
            DropForeignKey("dbo.Accounts", "Bank_Code", "dbo.Banks");
            DropIndex("dbo.Accounts", new[] { "SavingRelatedAccount_Code" });
            DropIndex("dbo.Accounts", new[] { "LoanRelatedAccount_Code" });
            DropIndex("dbo.Accounts", new[] { "Owner_Code" });
            DropIndex("dbo.Accounts", new[] { "Holder_Code" });
            DropIndex("dbo.Accounts", new[] { "Currency_CodeName" });
            DropIndex("dbo.Accounts", new[] { "Bank_Code" });
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
                    InterestNetRate = c.Decimal(precision: 18, scale: 2),
                    LoanEndDate = c.DateTime(storeType: "date"),
                    LoanInterestRate = c.Decimal(precision: 18, scale: 2),
                    PremiumPercentage = c.Decimal(precision: 18, scale: 2),
                    InterestCapitalization = c.Boolean(),
                    SavingEndDate = c.DateTime(storeType: "date"),
                    SavingInterestRate = c.Decimal(precision: 18, scale: 2),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                    Bank_Code = c.Guid(),
                    Currency_CodeName = c.String(nullable: false, maxLength: 10),
                    Holder_Code = c.Guid(),
                    Owner_Code = c.Guid(),
                    LoanRelatedAccount_Code = c.Guid(),
                    SavingRelatedAccount_Code = c.Guid(),
                })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Banks", t => t.Bank_Code)
                .ForeignKey("dbo.Currencies", t => t.Currency_CodeName, cascadeDelete: false)
                .ForeignKey("dbo.Persons", t => t.Holder_Code)
                .ForeignKey("dbo.Persons", t => t.Owner_Code)
                .ForeignKey("dbo.Accounts", t => t.LoanRelatedAccount_Code)
                .ForeignKey("dbo.Accounts", t => t.SavingRelatedAccount_Code)
                .Index(t => t.Bank_Code)
                .Index(t => t.Currency_CodeName)
                .Index(t => t.Holder_Code)
                .Index(t => t.Owner_Code)
                .Index(t => t.LoanRelatedAccount_Code)
                .Index(t => t.SavingRelatedAccount_Code);
        }
    }
}