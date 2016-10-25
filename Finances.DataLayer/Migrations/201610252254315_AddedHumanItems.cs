namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHumanItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Code = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Surname = c.String(nullable: false, maxLength: 200),
                        Email = c.String(maxLength: 200),
                        IsArchived = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ChangeAt = c.DateTime(nullable: false),
                        Owner_Code = c.Guid(),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Users", t => t.Owner_Code)
                .Index(t => t.Owner_Code);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Code = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Surname = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 200),
                        Nif = c.String(maxLength: 25),
                        SocialSecurity = c.String(),
                        HealthCare = c.String(maxLength: 25),
                        HealthCareExpirationDate = c.DateTime(nullable: false),
                        IdNumber = c.String(maxLength: 25),
                        IdNumberExpirationDate = c.DateTime(nullable: false),
                        Passport = c.String(maxLength: 25),
                        PassportExpirationDate = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ChangeAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Code)
                .Index(t => t.Email, unique: true);
            
            AlterColumn("dbo.Banks", "Country", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Banks", "Swift", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Banks", "ChangeAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "ChangeAt", c => c.DateTime());
            DropForeignKey("dbo.Persons", "Owner_Code", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Persons", new[] { "Owner_Code" });
            AlterColumn("dbo.Banks", "Swift", c => c.String());
            AlterColumn("dbo.Banks", "Country", c => c.String());
            DropTable("dbo.Users");
            DropTable("dbo.Persons");
            DropTable("dbo.Currencies");
        }
    }
}
