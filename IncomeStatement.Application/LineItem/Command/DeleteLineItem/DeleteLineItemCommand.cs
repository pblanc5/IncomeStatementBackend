using DomainResults.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.LineItem.Command.DeleteLineItem
{
    public sealed class DeleteLineItemCommand : IRequest<IDomainResult<int>>
    {
        public Guid Id { get; set; }
    }
}
