using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Statement
{
    public sealed class StatementAggregate<T> : AggregateRoot<T>
    {
        private readonly List<LineItem> _lineItems = new();

        private StatementAggregate(
            T id,
            int year,
            int month) : base(id)
        {
            Year = year;
            Month = month;
        }

        public int Year { get; set; }
        public int Month { get; set; }
        public IReadOnlyCollection<LineItem> LineItems { get { return _lineItems; }}
        public void AddLineItem(LineItem lineItem) => _lineItems.Add(lineItem); 
        public decimal Total => LineItems.Sum(l 
            => l.Type.Id == LineItemTypes.Profit.Id ? l.Amount : l.Amount * -1);

        public static StatementAggregate<Guid> Create(Guid id, int year, int month)
        {
            return new StatementAggregate<Guid>(id, year, month);
        }

        public static StatementAggregate<Guid> FromSnapshot(StatementSnapshot snapshot)
        {
            return new StatementAggregate<Guid>(snapshot.Id, snapshot.Year, snapshot.Month);
        }

    }
}
