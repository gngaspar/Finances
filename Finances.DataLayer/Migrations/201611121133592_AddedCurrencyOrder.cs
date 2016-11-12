namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCurrencyOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Currencies", "Order");
        }
    }
}
