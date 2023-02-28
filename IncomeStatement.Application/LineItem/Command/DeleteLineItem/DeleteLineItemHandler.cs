using DomainResults.Common;
using IncomeStatement.Domain.Common;
using MediatR;

namespace IncomeStatement.Application.LineItem.Command.DeleteLineItem
{
    internal sealed class DeleteLineItemHandler : IRequestHandler<DeleteLineItemCommand, IDomainResult<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLineItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDomainResult<int>> Handle(DeleteLineItemCommand request, CancellationToken cancellationToken)
        {
            var affectedRows = await _unitOfWork.LineItems.DeleteAsync(request.Id);
            _unitOfWork.Commit();

            if (affectedRows == 0)
            {
                return DomainResult.NotFound<int>();
            }

            return DomainResult.Success(affectedRows);
        }
    }
}
