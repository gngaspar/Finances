namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class MissingFields : DbMigration
    {
        public override void Up()
        {
            AddColumn( "dbo.Accounts", "AutomaticRenovation", c => c.String( maxLength: 100 ) );
            AddColumn( "dbo.Accounts", "InterestPayment", c => c.String( maxLength: 100 ) );
            AddColumn( "dbo.Parameterizations", "Cadence", c => c.String( maxLength: 100 ) );
        }

        public override void Down()
        {
            DropColumn( "dbo.Parameterizations", "Cadence" );
            DropColumn( "dbo.Accounts", "InterestPayment" );
            DropColumn( "dbo.Accounts", "AutomaticRenovation" );
        }
    }
}
