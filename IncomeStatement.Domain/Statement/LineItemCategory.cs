using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Statement
{
    public sealed class LineItemCategory
    {
        private List<LineItemSubcategory> _subCategories = new List<LineItemSubcategory>();

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IReadOnlyCollection<LineItemSubcategory> SubCategories { get => _subCategories; }

        public void AddSubcategoryRange(IEnumerable<LineItemSubcategory> subcategories)
        {
            _subCategories.AddRange(subcategories);
        }
    }
}
