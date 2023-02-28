namespace IncomeStatement.Domain.Statement;

public sealed class LineItemSnapshot 
{
    public Guid Id { get; set; }
    public Guid StatementId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? SubcategoryId { get; set; }
    public Guid TypeId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedOn { get; set; }
}
