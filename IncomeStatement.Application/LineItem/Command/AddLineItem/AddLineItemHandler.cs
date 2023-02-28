using DomainResults.Common;
using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.LineItem.Command.AddLineItem
{
    internal sealed class AddLineItemHandler : IRequestHandler<AddLineItemCommand, IDomainResult<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddLineItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDomainResult<int>> Handle(AddLineItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Statement.LineItem();
            entity.StatementId = request.StatementId;
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

            var affectedRows = await _unitOfWork.LineItems.CreateAsync(entity);
            _unitOfWork.Commit();

            return DomainResult.Success(affectedRows);
        }
    }
}
