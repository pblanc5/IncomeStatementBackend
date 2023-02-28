using IncomeStatement.Domain.Statement;
using IncomeStatement.Domain.Statement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.Statements.Query.GetStatement
{
    public sealed class GetStatementLineItemDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? Subcategory { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string LineItemType { get; set; } = string.Empty;

        public static GetStatementLineItemDto FromLineItem(Domain.Statement.LineItem lineItem)
        {
            return new GetStatementLineItemDto
            {
                Id = lineItem.Id,
                Description = lineItem.Description,
                Category = lineItem.Category.Name,
                Subcategory = lineItem.Subcategory?.Name,
                Amount = lineItem.Amount,
                LineItemType = lineItem.Type.Name
            };
        }
    }
}
