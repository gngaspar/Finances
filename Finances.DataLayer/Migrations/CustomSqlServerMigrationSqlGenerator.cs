namespace Finances.DataLayer.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.SqlServer;

    /// <summary>
    /// The custom server migration database generator.
    /// </summary>
    internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        /// <summary>
        /// The generate.
        /// </summary>
        /// <param name="addColumnOperation">
        /// The add column operation.
        /// </param>
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetCreatedColumn(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        /// <summary>
        /// The generate.
        /// </summary>
        /// <param name="createTableOperation">
        /// The create table operation.
        /// </param>
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetCreatedColumn(createTableOperation.Columns);

            base.Generate(createTableOperation);
        }

        /// <summary>
        /// The set created column.
        /// </summary>
        /// <param name="columns">
        /// The columns.
        /// </param>
        private static void SetCreatedColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (var columnModel in columns)
            {
                SetCreatedColumn(columnModel);
            }
        }

        /// <summary>
        /// The set created column.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        private static void SetCreatedColumn(PropertyModel column)
        {
            if ((column.Name == "CreatedAt" || column.Name == "ChangeAt") && column.Type == PrimitiveTypeKind.DateTime)
            {
                column.DefaultValueSql = "GETDATE()";
            }

            if (column.Name == "Code" && column.Type == PrimitiveTypeKind.Guid)
            {
                column.DefaultValueSql = "NEWID()";
            }
        }
    }
}