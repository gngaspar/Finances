namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsArchivedAccountPlastic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cards", "IsArchived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "IsArchived");
            DropColumn("dbo.Accounts", "IsArchived");
        }
    }
}
