using FluentMigrator;
using FluentMigrator.Builders.Execute;
using IncomeStatement.Domain.Statement.Enums;

namespace IncomeStatement.Database.Migrations
{
    [Migration(202201110001)]
    public class InitialSchema : Migration
    {
        public override void Up()
        {
            Execute.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");

            Create.Table("lineitem_category")
                .InSchema("income")
                .WithColumn("id")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(SystemMethods.NewGuid)
                .WithColumn("name")
                    .AsString()
                    .NotNullable();

            Create.Table("lineitem_subcategory")
                .InSchema("income")
                .WithColumn("id")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(SystemMethods.NewGuid)
                .WithColumn("name")
                    .AsString()
                    .NotNullable()
                .WithColumn("category_id")
                    .AsGuid()
                    .NotNullable()
                    .ForeignKey("lineitem_subcategory_lineitem_category_fk", "income", "lineitem_category", "id");

            Create.Table("lineitem_type")
                .InSchema("income")
                .WithColumn("id")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(SystemMethods.NewGuid)
                .WithColumn("name")
                    .AsString()
                    .NotNullable();

            Create.Table("statement")
                .InSchema("income")
                .WithColumn("id")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(SystemMethods.NewGuid)
                .WithColumn("year")
                    .AsInt16()
                    .NotNullable()
                .WithColumn("month")
                    .AsInt16()
                    .NotNullable()
                .WithColumn("created_at")
                    .AsDateTime()
                    .WithDefaultValue(SystemMethods.CurrentDateTime)
                .WithColumn("modified_on")
                    .AsDateTime();

            Create.Table("lineitem")
                .InSchema("income")
                .WithColumn("id")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(SystemMethods.NewGuid)
                .WithColumn("statement_id")
                    .AsGuid()
                    .NotNullable()
                    .ForeignKey("lineitem_statement_fk", "income", "statement", "id")
                .WithColumn("category_id")
                    .AsGuid()
                    .NotNullable()
                    .ForeignKey("lineitem_lineitem_category_fk", "income", "lineitem_category", "id")
                .WithColumn("subcategory_id")
                    .AsGuid()
                    .Nullable()
                    .ForeignKey("lineitem_lineitem_subcategory_fk", "income", "lineitem_subcategory", "id")
                .WithColumn("type_id")
                    .AsGuid()
                    .NotNullable()
                    .ForeignKey("lineitem_lineitem_type_fk", "income","lineitem_type", "id")
                .WithColumn("description")
                    .AsString()
                    .Nullable()
                .WithColumn("amount")
                    .AsCurrency()
                .WithColumn("created_at")
                    .AsDateTime()
                    .WithDefaultValue(SystemMethods.CurrentDateTime)
                .WithColumn("modified_on")
                    .AsDateTime();

            Insert.IntoTable("lineitem_type")
                .Row(new { id = LineItemTypes.Profit.Id, name = LineItemTypes.Profit.Name })
                .Row(new { id = LineItemTypes.Loss.Id, name = LineItemTypes.Loss.Name });
        }

        public override void Down()
        {
            Delete.Table("lineitem");
            Delete.Table("lineitem_type");
            Delete.Table("lineitem_subcategory");
            Delete.Table("lineitem_category");
            Delete.Table("statement");
            Delete.Schema("income");
        }
    }
}
