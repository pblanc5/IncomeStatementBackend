namespace IncomeStatement.Domain.Statement;

public sealed class LineItem
{
    public Guid Id { get; set; }
    public Guid StatementId { get; set; }
    public string Description { get; set; } = string.Empty;
    public LineItemCategory Category { get; set; } = new LineItemCategory();
    public LineItemSubcategory? Subcategory { get; set; }
    public LineItemType Type { get; set; } = new LineItemType();
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedOn { get; set; }

    public LineItemSnapshot ToSnapshot()
    {
        return new LineItemSnapshot
        {
            Id = Id,
            StatementId = StatementId,
            CategoryId = Category.Id,
            SubcategoryId = Subcategory?.Id,
            TypeId = Type.Id,
            Description = Description,
            Amount = Amount,
            CreatedAt = CreatedAt,
        };
    }
}
