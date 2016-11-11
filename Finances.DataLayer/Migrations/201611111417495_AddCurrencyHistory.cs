namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrencyHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrencyHistory",
                c => new
                    {
                        Currency = c.String(nullable: false, maxLength: 3),
                        CreatedAtDay = c.DateTime(nullable: false, storeType: "date"),
                        ReasonToOneEuro = c.Decimal(nullable: false, precision: 12, scale: 5),
                    })
                .PrimaryKey(t => new { t.Currency, t.CreatedAtDay });
            
            AlterColumn("dbo.Currencies", "ReasonToOneEuro", c => c.Decimal(nullable: false, precision: 12, scale: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Currencies", "ReasonToOneEuro", c => c.Decimal(nullable: false, precision: 12, scale: 2));
            DropTable("dbo.CurrencyHistory");
        }
    }
}
