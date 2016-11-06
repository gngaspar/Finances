namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedParameterizationEntity : DbMigration
    {
        public override void Up()
        {
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
                        Currency_CodeName = c.String(maxLength: 10),
                        FromAccount_Code = c.Guid(),
                        Owner_Code = c.Guid(nullable: false),
                        Parent_Code = c.Guid(),
                        ToAccount_Code = c.Guid(),
                        ToCard_Code = c.Guid(),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Currencies", t => t.Currency_CodeName)
                .ForeignKey("dbo.Accounts", t => t.FromAccount_Code)
                .ForeignKey("dbo.Persons", t => t.Owner_Code, cascadeDelete: true)
                .ForeignKey("dbo.Parameterizations", t => t.Parent_Code)
                .ForeignKey("dbo.Accounts", t => t.ToAccount_Code)
                .ForeignKey("dbo.Cards", t => t.ToCard_Code)
                .Index(t => t.Currency_CodeName)
                .Index(t => t.FromAccount_Code)
                .Index(t => t.Owner_Code)
                .Index(t => t.Parent_Code)
                .Index(t => t.ToAccount_Code)
                .Index(t => t.ToCard_Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parameterizations", "ToCard_Code", "dbo.Cards");
            DropForeignKey("dbo.Parameterizations", "ToAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Parameterizations", "Parent_Code", "dbo.Parameterizations");
            DropForeignKey("dbo.Parameterizations", "Owner_Code", "dbo.Persons");
            DropForeignKey("dbo.Parameterizations", "FromAccount_Code", "dbo.Accounts");
            DropForeignKey("dbo.Parameterizations", "Currency_CodeName", "dbo.Currencies");
            DropIndex("dbo.Parameterizations", new[] { "ToCard_Code" });
            DropIndex("dbo.Parameterizations", new[] { "ToAccount_Code" });
            DropIndex("dbo.Parameterizations", new[] { "Parent_Code" });
            DropIndex("dbo.Parameterizations", new[] { "Owner_Code" });
            DropIndex("dbo.Parameterizations", new[] { "FromAccount_Code" });
            DropIndex("dbo.Parameterizations", new[] { "Currency_CodeName" });
            DropTable("dbo.Parameterizations");
        }
    }
}
