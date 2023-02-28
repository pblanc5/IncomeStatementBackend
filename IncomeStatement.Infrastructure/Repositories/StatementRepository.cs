using Dapper;
using IncomeStatement.Domain.Statement;
using IncomeStatement.Domain.Statement.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Infrastructure.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        private readonly IDbConnection? _connection;
        private readonly ILogger _logger;

        public StatementRepository(IDbTransaction transaction, ILogger logger)
        {
            _connection = transaction.Connection;
            _logger = logger;
        }

        public int AddLineItem(StatementAggregate<Guid> statement)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(StatementAggregate<Guid> entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StatementAggregate<Guid>?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<StatementAggregate<Guid>> GetStatementByMonth(int year, int month)
        {
            var query = @"
                SELECT 
                    s.id,
                    s.year,
                    s.month,
                    s.created_at,
                    s.modified_on
                FROM income.statement s
                WHERE s.year=@year AND s.month=@month;";

            var result = await _connection.QueryAsync<StatementSnapshot>(query, new { year, month });
            var snapshot = result.FirstOrDefault();

            if (snapshot == null)
            {
                
            }

            var statement = StatementAggregate<Guid>.FromSnapshot(snapshot);

            var lineItems = await GetStatementLineItems(statement.Id);

            foreach (var lineItem in lineItems)
                statement.AddLineItem(lineItem);

            return statement;
        }

        public async Task<StatementAggregate<Guid>> GetStatementsByYear(int year)
        {
            var query = @"
                SELECT 
                    s.id,
                    s.year,
                    s.month,
                    s.created_at,
                    s.modified_on
                FROM income.statement s
                WHERE s.year=@year";

            var result = await _connection.QueryAsync<StatementSnapshot>(query, new { year });
            var snapshot = result.FirstOrDefault();

            if (snapshot == null)
            {

            }

            var statement = StatementAggregate<Guid>.FromSnapshot(snapshot);

            var lineItems = await GetStatementLineItems(statement.Id);

            foreach (var lineItem in lineItems)
                statement.AddLineItem(lineItem);

            return statement;
        }

        public Task<IReadOnlyList<StatementAggregate<Guid>>?> ListAsync(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(StatementAggregate<Guid> entity)
        {
            throw new NotImplementedException();
        }

        private async Task<IReadOnlyList<LineItem>> GetStatementLineItems(Guid statementId)
        {
            var query = @"
                SELECT
                    l.id,
                    l.description,
                    l.amount,
                    c.id,
                    c.name,
                    sc.id,
                    sc.name,
                    sc.category_id,
                    t.id,
                    t.name
                FROM income.lineitem l
                LEFT JOIN income.lineitem_category c ON l.category_id = c.id
                LEFT JOIN income.lineitem_subcategory sc ON l.subcategory_id = sc.id
                LEFT JOIN income.lineitem_type t ON l.type_id = t.id
                WHERE statement_id=@statementId";

            var result = await _connection.QueryAsync<LineItem, LineItemCategory, LineItemSubcategory, LineItemType, LineItem>(query,
                (lineItem, category, subcategory, type) => {
                    lineItem.Category = category;
                    lineItem.Subcategory = subcategory;
                    lineItem.Type = type;
                    return lineItem;
                },
                new { statementId });

            return result.ToList();
        }
    }
}
