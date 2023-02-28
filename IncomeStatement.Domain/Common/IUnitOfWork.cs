using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeStatement.Domain.Statement;
using IncomeStatement.Domain.Statement.Interfaces;

namespace IncomeStatement.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IStatementRepository Statements { get; }
        IRepository<LineItem> LineItems { get; }
        IRepository<LineItemCategory> Categories { get; }
        IRepository<LineItemSubcategory> Subcategories { get; }
        void Commit();
    }
}
