using System.ComponentModel.DataAnnotations;

namespace IncomeStatement.API.Requests
{
    public sealed class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
