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
    public sealed class SubcategoryRepository : IRepository<LineItemSubcategory>
    {
        private readonly IDbConnection? _connection;
        private readonly ILogger _logger;

        public SubcategoryRepository(IDbTransaction transaction, ILogger logger)
        {
            _connection = transaction.Connection;
            _logger = logger;
        }

        public async Task<int> CreateAsync(LineItemSubcategory entity)
        {
            var command = @"
                INSERT INTO income.lineitem_subcategory (name, category_id)
                VALUES (@name, @category_id)";

            return await _connection.ExecuteAsync(command, new { name = entity.Name, category_id=entity.CategoryId });
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var command = @"
                DELETE FROM income.lineitem_subcategory
                WHERE id=@id";

            return await _connection.ExecuteAsync(command, new { id });
        }

        public Task<LineItemSubcategory?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<LineItemSubcategory>?> ListAsync(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(LineItemSubcategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
