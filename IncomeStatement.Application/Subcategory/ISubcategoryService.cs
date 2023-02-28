using DomainResults.Common;

namespace IncomeStatement.Application.Subcategory
{
    public interface ISubcategoryService
    {
        public Task<IDomainResult> AddSubcategory(string name, Guid categoryId);
        public Task<IDomainResult> RemoveSubcategory(Guid id);
    }
}
