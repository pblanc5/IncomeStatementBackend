using Dapper;
using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement;
using IncomeStatement.Domain.Statement.Interfaces;
using IncomeStatement.Infrastructure.Persistance;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Immutable;
using System.Data;
using static Dapper.SqlMapper;

namespace IncomeStatement.Infrastructure.Repositories
{
    public class LineItemRespository : IRepository<LineItem>
    {
        private readonly IDbConnection? _connection;
        private readonly ILogger _logger;

        public LineItemRespository(IDbTransaction transaction, ILogger logger)
        {
            _connection = transaction.Connection;
            _logger = logger;
        }

        public async Task<int> CreateAsync(LineItem entity)
        {
            var snapshot = entity.ToSnapshot();

            var command = @"
                INSERT INTO income.lineitem (id, description, statement_id, category_id, subcategory_id, type_id, amount, created_at, modified_on) 
                VALUES (@id, @description, @statement, @category, @subcategory, @type, @amount, @createdAt, @modifiedOn)";
            
            var result = await _connection.ExecuteAsync(command, new
            {
                id = Guid.NewGuid(),
                description = snapshot.Description,
                statement = snapshot.StatementId,
                category = snapshot.CategoryId,
                subcategory = snapshot.SubcategoryId,
                type = snapshot.TypeId,
                amount = snapshot.Amount,
                createdAt = DateTime.Now,
                modifiedOn = DateTime.Now,
            });

            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var command = @"
                DELETE FROM income.lineitem
                WHERE id=@id";

            var result = await _connection.ExecuteAsync(command, new { id });
            return result;
        }

        public async Task<LineItem?> GetByIdAsync(Guid id)
        {
            var query = @"
                SELECT l.*, c.*, sc.*, t.*
                FROM income.lineitem l
                LEFT JOIN income.lineitem_category c ON l.category_id = c.id
                LEFT JOIN income.lineitem_subcategory sc ON l.subcategory_id = sc.id
                LEFT JOIN income.lineitem_type t ON l.type_id = t.id
                WHERE l.id=@id;";

            var result = await _connection.QueryAsync<LineItem, LineItemCategory, LineItemSubcategory, Domain.Statement.LineItemType, LineItem>(query, 
                (statement, category, subcategory, type) => { 
                    statement.Category = category;
                    statement.Subcategory = subcategory;
                    statement.Type = type;
                    return statement;
                }, new { id });

            return result.FirstOrDefault();
        }

        public Task<IReadOnlyList<LineItem>?> ListAsync(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(LineItem entity)
        {

            var snapshot = entity.ToSnapshot();

            var command = @"
                UPDATE income.lineitem 
                SET description=@description, category=@category, subcategory=@subcategory, type=@type, amount=@amount modified_on=@modifiedOn
                WHERE id=@id";

            var result = await _connection.ExecuteAsync(command, new
            {
                id = snapshot.Id,
                description = snapshot.Description,
                category = snapshot.CategoryId,
                subcategory = snapshot.SubcategoryId,
                type = snapshot.TypeId,
                amount = snapshot.Amount,
                modifiedOn = snapshot.ModifiedOn
            });
            return result;
        }
    }
}
