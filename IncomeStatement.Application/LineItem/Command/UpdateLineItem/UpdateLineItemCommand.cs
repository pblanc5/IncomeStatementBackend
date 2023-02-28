using DomainResults.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.LineItem.Command.UpdateLineItem
{
    public sealed class UpdateLineItemCommand : IRequest<IDomainResult<int>>
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubcategoryId { get; set; }
        public Guid TypeId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
