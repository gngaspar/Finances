namespace Finances.DataLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCards : DbMigration
    {
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "Owner_Code", "dbo.Persons");
            DropForeignKey("dbo.Cards", "Holder_Code", "dbo.Persons");
            DropForeignKey("dbo.Cards", "Currency_CodeName", "dbo.Currencies");
            DropForeignKey("dbo.Cards", "Bank_Code", "dbo.Banks");
            DropForeignKey("dbo.Cards", "Account_Code", "dbo.Accounts");
            DropIndex("dbo.Cards", new[] { "Owner_Code" });
            DropIndex("dbo.Cards", new[] { "Holder_Code" });
            DropIndex("dbo.Cards", new[] { "Currency_CodeName" });
            DropIndex("dbo.Cards", new[] { "Bank_Code" });
            DropIndex("dbo.Cards", new[] { "Account_Code" });
            DropTable("dbo.Cards");
        }

        public override void Up()
        {
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
                    Discriminator = c.String(nullable: false, maxLength: 128),
                    Account_Code = c.Guid(nullable: false),
                    Bank_Code = c.Guid(nullable: false),
                    Currency_CodeName = c.String(nullable: false, maxLength: 10),
                    Holder_Code = c.Guid(nullable: false),
                    Owner_Code = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Accounts", t => t.Account_Code, cascadeDelete: false)
                .ForeignKey("dbo.Banks", t => t.Bank_Code, cascadeDelete: false)
                .ForeignKey("dbo.Currencies", t => t.Currency_CodeName, cascadeDelete: false)
                .ForeignKey("dbo.Persons", t => t.Holder_Code, cascadeDelete: false)
                .ForeignKey("dbo.Persons", t => t.Owner_Code, cascadeDelete: false)
                .Index(t => t.Account_Code)
                .Index(t => t.Bank_Code)
                .Index(t => t.Currency_CodeName)
                .Index(t => t.Holder_Code)
                .Index(t => t.Owner_Code);
        }
    }
}