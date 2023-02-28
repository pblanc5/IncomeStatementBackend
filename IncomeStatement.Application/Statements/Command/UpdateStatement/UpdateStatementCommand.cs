using MediatR;

namespace IncomeStatement.Application.Statements.Command.UpdateStatement
{
    public sealed class UpdateStatementCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
    }
}
