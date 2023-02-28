using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.Category.DTOs
{
    public sealed class ListCategoriesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<ListSubcategoryDto> SubCategories { get; set; } = Enumerable.Empty<ListSubcategoryDto>();
    }
}
