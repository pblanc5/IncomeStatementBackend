using IncomeStatement.Domain.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.Statements.Query.GetStatement
{
    public sealed class GetStatementDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Total { get; set; }
        public List<GetStatementLineItemDto> LineItems { get; set; } = new List<GetStatementLineItemDto>();
    }
}
