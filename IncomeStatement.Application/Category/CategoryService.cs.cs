using DomainResults.Common;
using IncomeStatement.Application.Category.DTOs;
using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDomainResult> AddCategory(string name)
        {
            var category = new LineItemCategory
            {
                Name = name,
            };

            var affectedRows = await _unitOfWork.Categories.CreateAsync(category);
            _unitOfWork.Commit();

            if (affectedRows != 1)
            {
                return DomainResult.Failed("Unable to create category");
            }

            return DomainResult.Success();
        }

        public async Task<IDomainResult> DeleteCategory(Guid id)
        {
            var affectedRows = await _unitOfWork.Categories.DeleteAsync(id);
            _unitOfWork.Commit();

            if (affectedRows != 1)
            {
                return DomainResult.Failed("Unable to delete category");
            }

            return DomainResult.Success();
        }

        public async Task<IDomainResult<IEnumerable<ListCategoriesDto>>> ListCategories()
        {
            var categories = await _unitOfWork.Categories.ListAsync(0, 0);

            if (categories == null)
                return DomainResult.Failed<IEnumerable<ListCategoriesDto>>("category list could not be returned");

            return DomainResult.Success(categories.Select( c => new ListCategoriesDto
            {
                Id = c.Id,
                Name = c.Name,
                SubCategories = c.SubCategories.Select(s 
                    => new ListSubcategoryDto
                    {
                        Id = s.Id, 
                        Name = s.Name,
                    }),
            }));
        }

        public Task<IDomainResult> UpdateCategory(Guid id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
