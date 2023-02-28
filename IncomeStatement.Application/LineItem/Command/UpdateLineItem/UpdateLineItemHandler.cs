using DomainResults.Common;
using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement.Enums;
using MediatR;

namespace IncomeStatement.Application.LineItem.Command.UpdateLineItem
{
    internal sealed class UpdateLineItemHandler : IRequestHandler<UpdateLineItemCommand, IDomainResult<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLineItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDomainResult<int>> Handle(UpdateLineItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Statement.LineItem();
            entity.Id = request.Id;
            entity.Category.Id = request.CategoryId;
            entity.Description = request.Description;
            entity.Amount = request.Amount;

            if (request.SubcategoryId.HasValue)
                entity.Subcategory = new Domain.Statement.LineItemSubcategory
                {
                    Id = request.SubcategoryId.Value,
                };

            var type = Enumeration.GetById<LineItemTypes>(request.TypeId);

            entity.Type = new Domain.Statement.LineItemType
            {
                Id = type.Id,
                Name = type.Name,
            };

            var affectedRows = await _unitOfWork.LineItems.UpdateAsync(entity);
            _unitOfWork.Commit();

            return DomainResult.Success(affectedRows);
        }
    }
}
