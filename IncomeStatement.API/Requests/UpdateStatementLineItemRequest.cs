using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IncomeStatement.API.Requests
{
    public sealed class UpdateStatementLineItemRequest
    {
        [BindRequired]
        public string Description { get; set; } = string.Empty;

        [BindRequired]
        public Guid CategoryId { get; set; }

        public Guid SubcategoryId { get; set; }

        [BindRequired]
        public Guid LineItemTypeId { get; set; }

        [BindRequired]
        public decimal Amount { get; set; }
    }
}
