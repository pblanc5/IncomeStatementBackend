using IncomeStatement.Domain.Common;
using MediatR;

namespace IncomeStatement.Application.Statements.Command.DeleteStatement
{
    internal sealed class DeleteStatementHandler : IRequestHandler<DeleteStatementCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStatementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteStatementCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Statements.DeleteAsync(request.Id);
        }
    }
}
