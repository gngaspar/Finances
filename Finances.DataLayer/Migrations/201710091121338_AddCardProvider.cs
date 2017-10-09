namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCardProvider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "CardProvider", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "CardProvider");
        }
    }
}
