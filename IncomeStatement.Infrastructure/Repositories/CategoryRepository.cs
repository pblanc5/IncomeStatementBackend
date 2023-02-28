using Dapper;
using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Infrastructure.Repositories
{
    internal class CategoryRepository : IRepository<LineItemCategory>
    {
        private readonly IDbConnection? _connection;
        private readonly ILogger _logger;

        public CategoryRepository(IDbTransaction transaction, ILogger logger)
        {
            _connection = transaction.Connection;
            _logger = logger;
        }

        public async Task<int> CreateAsync(LineItemCategory entity)
        {
            var command = @"
                INSERT INTO income.lineitem_category (name)
                VALUES (@name)";

            return await _connection.ExecuteAsync(command, new { name = entity.Name });
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var command = @"
                DELETE FROM income.lineitem_category
                WHERE id=@id";

            return await _connection.ExecuteAsync(command, new { id });
        }

        public Task<LineItemCategory?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<LineItemCategory>?> ListAsync(int offset, int limit)
        {
            var query = @"
                SELECT
                    id,
                    name
                FROM income.lineitem_category";

            var categories = await _connection.QueryAsync<LineItemCategory>(query);
            foreach (var category in categories)
            {
                var subcategories = await ListSubcategories(category.Id);
                category.AddSubcategoryRange(subcategories);
            }

            return categories.ToList();
        }

        public Task<int> UpdateAsync(LineItemCategory entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<LineItemSubcategory>> ListSubcategories(Guid categoryId)
        {
            var query = @"
                SELECT
                    id,
                    name
                FROM income.lineitem_subcategory
                WHERE category_id=@category_id";

            var subcategories = await _connection.QueryAsync<LineItemSubcategory>(query, new { category_id = categoryId });
            return subcategories.ToList();
        }
    }
}
