namespace Finances.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.IO;

    using Finances.DataLayer.Migrations;

    internal class Program
    {
        private const string InitialDatabase = "0";

        private const string ModuleName = "Banking";

        private static void Main(string[] args)
        {
            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            var scriptor = new MigratorScriptingDecorator(migrator);

            var script = "USE " + ModuleName + " " + Environment.NewLine + Environment.NewLine;
            script = script + scriptor.ScriptUpdate(InitialDatabase, null);
            Console.Write( "Starting :" );
            File.WriteAllText(@"C:/BankingScript.sql", script);
            Console.Write("Ended");
        }
    }
}
