using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Statement
{
    public sealed class LineItemSubcategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }
}
