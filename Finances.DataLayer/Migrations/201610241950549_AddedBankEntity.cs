namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBankEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Code = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ChangeAt = c.DateTime(),
                        Name = c.String(nullable: false),
                        Url = c.String(),
                        Country = c.String(),
                        Swift = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Banks");
        }
    }
}
