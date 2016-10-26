namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Code = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 5),
                        Swift = c.String(nullable: false, maxLength: 50),
                        Url = c.String(maxLength: 250),
                        ChangeAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Code)
                .Index(t => t.Swift, unique: true);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 10),
                        ReasonToOneEuro = c.Decimal(nullable: false, precision: 12, scale: 2),
                        ChangeAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
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
                        ChangeAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Code = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 200),
                        Surname = c.String(nullable: false, maxLength: 200),
                        IdNumber = c.String(maxLength: 25),
                        IdNumberExpirationDate = c.DateTime(nullable: false, storeType: "date"),
                        Passport = c.String(maxLength: 25),
                        PassportExpirationDate = c.DateTime(nullable: false, storeType: "date"),
                        Nif = c.String(maxLength: 25),
                        HealthCare = c.String(maxLength: 25),
                        SocialSecurity = c.String(maxLength: 25),
                        ChangeAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        HealthCareExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Code)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Banks", new[] { "Swift" });
            DropTable("dbo.Users");
            DropTable("dbo.Persons");
            DropTable("dbo.Currencies");
            DropTable("dbo.Banks");
        }
    }
}
