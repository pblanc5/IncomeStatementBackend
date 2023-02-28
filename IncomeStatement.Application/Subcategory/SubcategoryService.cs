using DomainResults.Common;
using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.Subcategory
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubcategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDomainResult> AddSubcategory(string name, Guid categoryId)
        {
            var subcategory = new LineItemSubcategory
            {
                Name = name,
                CategoryId = categoryId
            };

            var affectedRows = await _unitOfWork.Subcategories.CreateAsync(subcategory);

            if (affectedRows != 1)
                return DomainResult.Failed("Unable to add subcategory");

            return DomainResult.Success();
        }

        public async Task<IDomainResult> RemoveSubcategory(Guid id)
        {
            var affectedRows = await _unitOfWork.Subcategories.DeleteAsync(id);

            if (affectedRows != 1)
                return DomainResult.Failed("Unable to remove subcategory");

            return DomainResult.Success();
        }
    }
}
