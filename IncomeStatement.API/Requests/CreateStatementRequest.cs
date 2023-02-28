using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IncomeStatement.API.Requests
{
    public sealed class CreateStatementRequest
    {
        [BindRequired]
        public short Year { get; set; }

        [BindRequired]
        public short Month { get; set; }
    }
}
