namespace Finances.DataLayer.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.SqlServer;

    internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetCreatedColumn(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetCreatedColumn(createTableOperation.Columns);

            base.Generate(createTableOperation);
        }

        private static void SetCreatedColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (var columnModel in columns)
            {
                SetCreatedColumn(columnModel);
            }
        }

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