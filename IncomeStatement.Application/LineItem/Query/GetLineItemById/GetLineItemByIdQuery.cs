using DomainResults.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.LineItem.Query.GetLineItemById;

public sealed class GetLineItemByIdQuery : IRequest<IDomainResult<GetLineItemDto>>
{
    public Guid Id { get; set; }
}
