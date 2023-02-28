namespace IncomeStatement.API.Responses
{
    public sealed class ErrorResponse
    {
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
