namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrePaidHasCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "AvailableAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Cards", "MaximumAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "MaximumAmount");
            DropColumn("dbo.Cards", "AvailableAmount");
        }
    }
}
