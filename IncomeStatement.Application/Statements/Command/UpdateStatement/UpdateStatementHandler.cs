using IncomeStatement.Domain.Common;
using MediatR;

namespace IncomeStatement.Application.Statements.Command.UpdateStatement
{
    internal sealed class UpdateStatementHandler : IRequestHandler<UpdateStatementCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStatementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateStatementCommand request, CancellationToken cancellationToken)
        {
            var statement = await _unitOfWork.Statements.GetByIdAsync(request.Id);

            if (statement is null)
            {
                return 0;
            }

            statement.Year = request.Year;
            statement.Month = request.Month;

            return await _unitOfWork.Statements.UpdateAsync(statement);
        }
    }
}
