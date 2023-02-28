using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Database.Migrations
{
    [Migration(202302110002)]
    public class SeedDatabase : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Insert.IntoTable("lineitem_category")
                .Row(new { id = new Guid("74fbcaf6-7fa2-48ad-9ac4-979e336c76df"), name = "Entertainment" })
                .Row(new { id = new Guid("d3f9b28c-c00b-4982-a6ed-2195725c4719"), name = "Groceries" })
                .Row(new { id = new Guid("abc1d433-380f-43c5-abe5-db3844814e64"), name = "Medical" })
                .Row(new { id = new Guid("f5f854e9-a5d0-4f2a-993f-e3ce41ce4252"), name = "Fitness" })
                .Row(new { id = new Guid("9b8023ff-8f68-49c0-aa5c-a8dadb392baf"), name = "Transportation" })
                .Row(new { id = new Guid("87412c6e-1f92-4ee7-97d3-99d5c8cd2396"), name = "Education" })
                .Row(new { id = new Guid("942c202a-8d35-497f-b3c7-15946baaef3b"), name = "Occupation" });

            Insert.IntoTable("lineitem_subcategory")
                .Row(new { id = new Guid("4a70f53c-355e-4794-b32b-9fbdce2d03b1"), category_id = new Guid("74fbcaf6-7fa2-48ad-9ac4-979e336c76df"), name = "Video Games" })
                .Row(new { id = new Guid("a356faea-3717-4b61-9b86-be84ec45277c"), category_id = new Guid("74fbcaf6-7fa2-48ad-9ac4-979e336c76df"), name = "Streaming Services" })
                .Row(new { id = new Guid("fa0cf42f-2634-4751-b1ed-2c84beed359f"), category_id = new Guid("9b8023ff-8f68-49c0-aa5c-a8dadb392baf"), name = "Personal Vehicle" })
                .Row(new { id = new Guid("9522586a-97bc-41b1-b279-98280d3b6a4c"), category_id = new Guid("9b8023ff-8f68-49c0-aa5c-a8dadb392baf"), name = "Bus" })
                .Row(new { id = new Guid("20d83df2-a8a1-4a5c-b93d-e95b531502cc"), category_id = new Guid("9b8023ff-8f68-49c0-aa5c-a8dadb392baf"), name = "Train" })
                .Row(new { id = new Guid("c4046629-6b2a-497f-b72c-45edc0199fe8"), category_id = new Guid("9b8023ff-8f68-49c0-aa5c-a8dadb392baf"), name = "Airplane" });


            Insert.IntoTable("statement")
                .Row(new { id = new Guid("fbb5e7ee-dd9d-4375-99c6-536b60949131"), year = 2023, month = 1, created_at = DateTime.Now, modified_on = DateTime.Now })
                .Row(new { id = new Guid("c231b06b-77cb-4863-9c19-d633c0417f21"), year = 2023, month = 2, created_at = DateTime.Now, modified_on = DateTime.Now });

            Insert.IntoTable("lineitem")
                .Row(new
                {
                    id = new Guid("a2696655-c162-48f2-8b56-6ec8b13ec67f"),
                    statement_id = new Guid("fbb5e7ee-dd9d-4375-99c6-536b60949131"),
                    category_id = new Guid("87412c6e-1f92-4ee7-97d3-99d5c8cd2396"),
                    type_id = new Guid("4126efb0-6010-4d68-80e2-2dbe290a85f7"),
                    description = "Udemy",
                    amount = 30,
                    created_at = DateTime.Now,
                    modified_on = DateTime.Now
                })
                .Row(new
                {
                    id = new Guid("82bdef43-4eb4-4632-a5ef-5fe1ba24d27f"),
                    statement_id = new Guid("fbb5e7ee-dd9d-4375-99c6-536b60949131"),
                    category_id = new Guid("9b8023ff-8f68-49c0-aa5c-a8dadb392baf"),
                    subcategory_id = new Guid("fa0cf42f-2634-4751-b1ed-2c84beed359f"),
                    type_id = new Guid("4126efb0-6010-4d68-80e2-2dbe290a85f7"),
                    description = "Oil Change",
                    amount = 7,
                    created_at = DateTime.Now,
                    modified_on = DateTime.Now
                })
                .Row(new
                {
                    id = new Guid("381ce123-a3dc-452c-8718-c85c913b6dfe"),
                    statement_id = new Guid("fbb5e7ee-dd9d-4375-99c6-536b60949131"),
                    category_id = new Guid("74fbcaf6-7fa2-48ad-9ac4-979e336c76df"),
                    subcategory_id = new Guid("4a70f53c-355e-4794-b32b-9fbdce2d03b1"),
                    type_id = new Guid("4126efb0-6010-4d68-80e2-2dbe290a85f7"),
                    description = "Steam",
                    amount = 50,
                    created_at = DateTime.Now,
                    modified_on = DateTime.Now
                })
                .Row(new
                {
                    id = new Guid("2da0475f-6a7a-4c7b-8e44-5e7345248a51"),
                    statement_id = new Guid("c231b06b-77cb-4863-9c19-d633c0417f21"),
                    category_id = new Guid("74fbcaf6-7fa2-48ad-9ac4-979e336c76df"),
                    subcategory_id = new Guid("a356faea-3717-4b61-9b86-be84ec45277c"),
                    type_id = new Guid("4126efb0-6010-4d68-80e2-2dbe290a85f7"),
                    description = "Netflix",
                    amount = 15,
                    created_at = DateTime.Now,
                    modified_on = DateTime.Now
                })
                .Row(new
                {
                    id = new Guid("8dedbc44-6586-40df-a290-56514c712a1e"),
                    statement_id = new Guid("c231b06b-77cb-4863-9c19-d633c0417f21"),
                    category_id = new Guid("942c202a-8d35-497f-b3c7-15946baaef3b"),
                    type_id = new Guid("fb16ac80-89f8-44a4-885e-41c327eea48e"),
                    description = "Salary",
                    amount = 6300,
                    created_at = DateTime.Now,
                    modified_on = DateTime.Now
                });
        }
    }
}
