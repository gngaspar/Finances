﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.IO;
    using Finances.DataLayer.Migrations;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The initial database.
        /// </summary>
        private const string InitialDatabase = "0";

        /// <summary>
        /// The module name.
        /// </summary>
        private const string ModuleName = "Banking";

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main( string[] args )
        {
            Console.WriteLine( $"{DateTime.Now} Starting" );

            Console.WriteLine( $"{DateTime.Now} Configuration started" );
            var configuration = new Configuration();
            Console.WriteLine( $"{DateTime.Now} Configuration loaded" );

            Console.WriteLine( $"{DateTime.Now} DbMigrator started" );
            var migrator = new DbMigrator( configuration );
            Console.WriteLine( $"{DateTime.Now} DbMigrator loaded" );

            Console.WriteLine( $"{DateTime.Now} Scripting Decorator started" );
            var scriptor = new MigratorScriptingDecorator( migrator );
            Console.WriteLine( $"{DateTime.Now} Scripting Decorator loaded" );

            var script = "USE " + ModuleName + " " + Environment.NewLine + Environment.NewLine;
            script = script + scriptor.ScriptUpdate( InitialDatabase, null );

            Console.WriteLine( $"{DateTime.Now} Starting File Writing" );
            try
            {
                string path = @"C:\Logs";
                if ( !Directory.Exists( path ) )
                {
                    Directory.CreateDirectory( path );
                }

                File.WriteAllText( @"C:\Logs\BankingScript.sql", script );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"{DateTime.Now} Error File Writing" );
                Console.WriteLine( ex.Message );
                if ( ex.Message.Contains( "denied" ) || ex.Message.Contains( "access" ) )
                {
                    Console.WriteLine( "Try running application as administrator." );
                }

                Console.ReadKey();
            }
        }
    }
}