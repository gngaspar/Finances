namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "Bank_Code", "dbo.Banks");
            DropForeignKey("dbo.Accounts", "Owner_Code", "dbo.Persons");
            DropIndex("dbo.Accounts", new[] { "Bank_Code" });
            DropIndex("dbo.Accounts", new[] { "Owner_Code" });
            AlterColumn("dbo.Accounts", "Bank_Code", c => c.Guid(nullable: false));
            AlterColumn("dbo.Accounts", "Owner_Code", c => c.Guid(nullable: false));
            CreateIndex("dbo.Accounts", "Bank_Code");
            CreateIndex("dbo.Accounts", "Owner_Code");
            AddForeignKey("dbo.Accounts", "Bank_Code", "dbo.Banks", "Code", cascadeDelete: true);
            AddForeignKey("dbo.Accounts", "Owner_Code", "dbo.Persons", "Code", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "Owner_Code", "dbo.Persons");
            DropForeignKey("dbo.Accounts", "Bank_Code", "dbo.Banks");
            DropIndex("dbo.Accounts", new[] { "Owner_Code" });
            DropIndex("dbo.Accounts", new[] { "Bank_Code" });
            AlterColumn("dbo.Accounts", "Owner_Code", c => c.Guid());
            AlterColumn("dbo.Accounts", "Bank_Code", c => c.Guid());
            CreateIndex("dbo.Accounts", "Owner_Code");
            CreateIndex("dbo.Accounts", "Bank_Code");
            AddForeignKey("dbo.Accounts", "Owner_Code", "dbo.Persons", "Code");
            AddForeignKey("dbo.Accounts", "Bank_Code", "dbo.Banks", "Code");
        }
    }
}
