using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Statement
{
    public sealed class LineItemType
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
