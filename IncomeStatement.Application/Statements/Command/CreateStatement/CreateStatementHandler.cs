using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement;
using MediatR;

namespace IncomeStatement.Application.Statements.Command.CreateStatement
{
    internal sealed class CreateStatementHandler : IRequestHandler<CreateStatementCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateStatementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var statement = StatementAggregate<Guid>.Create(id, request.Year, request.Month);

            return await _unitOfWork.Statements.CreateAsync(statement);
        }
    }
}
