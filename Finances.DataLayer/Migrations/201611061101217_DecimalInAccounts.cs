namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecimalInAccounts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "InterestNetRate", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("dbo.Accounts", "LoanInterestRate", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("dbo.Accounts", "PremiumPercentage", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("dbo.Accounts", "SavingInterestRate", c => c.Decimal(precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "SavingInterestRate", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Accounts", "PremiumPercentage", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Accounts", "LoanInterestRate", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Accounts", "InterestNetRate", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
