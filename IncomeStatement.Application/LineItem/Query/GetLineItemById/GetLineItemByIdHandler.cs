using DomainResults.Common;
using IncomeStatement.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.LineItem.Query.GetLineItemById
{
    internal class GetLineItemByIdHandler : IRequestHandler<GetLineItemByIdQuery, IDomainResult<GetLineItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLineItemByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDomainResult<GetLineItemDto>> Handle(GetLineItemByIdQuery request, CancellationToken cancellationToken)
        {
            var lineItem = await _unitOfWork.LineItems.GetByIdAsync(request.Id);

            if (lineItem == null)
            {
                return DomainResult.NotFound<GetLineItemDto>();
            }

            var dto = new GetLineItemDto
            {
                Id = lineItem.Id,
                StatementId = lineItem.StatementId,
                Category = lineItem.Category,
                Subcategory = lineItem.Subcategory,
                Type = lineItem.Type,
                Description = lineItem.Description,
                Amount = lineItem.Amount,
            };

            return DomainResult.Success(dto);
        }
    }
}
