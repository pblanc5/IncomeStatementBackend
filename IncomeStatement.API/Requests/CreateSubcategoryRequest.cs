using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IncomeStatement.API.Requests
{
    public sealed class CreateSubcategoryRequest
    {
        [BindRequired]
        public string Name { get; set; } = string.Empty;
        [BindRequired]
        public Guid CategoryId { get; set; }
    }
}
