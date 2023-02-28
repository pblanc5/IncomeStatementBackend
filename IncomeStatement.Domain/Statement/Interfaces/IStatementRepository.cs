using IncomeStatement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Statement.Interfaces
{
    public interface IStatementRepository : IRepository<StatementAggregate<Guid>>
    {
        public int AddLineItem(StatementAggregate<Guid> statement);
        public Task<StatementAggregate<Guid>> GetStatementByMonth(int year, int month);
        public Task<StatementAggregate<Guid>> GetStatementsByYear(int year);
    }
}
