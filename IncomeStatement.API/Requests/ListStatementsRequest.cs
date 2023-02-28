using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace IncomeStatement.API.Requests
{
    public sealed class ListStatementsRequest
    {
        public int Year { get; set; }

        [Range(1, 12)]
        public int? Month { get; set; }
    }
}
