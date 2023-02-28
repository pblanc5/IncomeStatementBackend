using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IncomeStatement.API.Requests
{
    public sealed class ListSubcategoriesRequest
    {
        [BindRequired]
        public Guid CategoryId { get; set; }
    }
}
