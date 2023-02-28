using IncomeStatement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Statement.Enums
{
    public sealed class LineItemTypes : Enumeration
    {
        public static readonly LineItemTypes Profit = new LineItemTypes(new Guid("fb16ac80-89f8-44a4-885e-41c327eea48e"), nameof(Profit));
        public static readonly LineItemTypes Loss = new LineItemTypes(new Guid("4126efb0-6010-4d68-80e2-2dbe290a85f7"), nameof(Loss));

        public LineItemTypes(Guid id, string name) : base(id, name)
        {
        }
    }
}
