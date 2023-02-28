using MediatR;

namespace IncomeStatement.Application.Statements.Command.DeleteStatement
{
    public sealed class DeleteStatementCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
