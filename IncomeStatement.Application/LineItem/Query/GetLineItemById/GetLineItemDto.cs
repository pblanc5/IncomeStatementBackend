using IncomeStatement.Domain.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.LineItem.Query.GetLineItemById
{
    public sealed class GetLineItemDto
    {
        public Guid Id { get; set; }
        public Guid StatementId { get; set; }
        public string Description { get; set; } = string.Empty;
        public LineItemCategory? Category { get; set; }
        public LineItemSubcategory? Subcategory { get; set; }
        public LineItemType? Type { get; set; }
        public decimal Amount { get; set; }
    }
}
