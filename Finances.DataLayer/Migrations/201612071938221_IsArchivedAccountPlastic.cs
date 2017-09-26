// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201612071938221_IsArchivedAccountPlastic.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the IsArchivedAccountPlastic type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The is archived account plastic.
    /// </summary>
    public partial class IsArchivedAccountPlastic : DbMigration
    {
        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            AddColumn( "dbo.Accounts", "IsArchived", c => c.Boolean( nullable: false ) );
            AddColumn( "dbo.Cards", "IsArchived", c => c.Boolean( nullable: false ) );
        }

        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            DropColumn( "dbo.Cards", "IsArchived" );
            DropColumn( "dbo.Accounts", "IsArchived" );
        }
    }
}
