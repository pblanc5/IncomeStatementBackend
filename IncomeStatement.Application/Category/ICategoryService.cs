using DomainResults.Common;
using IncomeStatement.Application.Category.DTOs;
using IncomeStatement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.Category
{
    public interface ICategoryService
    {
        public Task<IDomainResult<IEnumerable<ListCategoriesDto>>> ListCategories();
        public Task<IDomainResult> AddCategory(string name);
        public Task<IDomainResult> UpdateCategory(Guid id, string name);
        public Task<IDomainResult> DeleteCategory(Guid id);
    }
}
