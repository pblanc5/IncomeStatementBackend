using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.Statements.Query.GetStatement
{
    internal class GetStatementQueryHandler : IRequestHandler<GetStatementQuery, GetStatementDto>
    {
        private IUnitOfWork _unitOfWork;

        public GetStatementQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetStatementDto> Handle(GetStatementQuery request, CancellationToken cancellationToken)
        {
            StatementAggregate<Guid> statement;

            if (request.Month.HasValue)
            {
                statement = await _unitOfWork.Statements.GetStatementByMonth(request.Year, request.Month.Value);
            }
            else
            {
                statement = await _unitOfWork.Statements.GetStatementsByYear(request.Year);
            }

            var dto = new GetStatementDto
            {
                Id = statement.Id,
                Year = statement.Year,
                Month = statement.Month,
                Total = statement.Total,
                LineItems = statement.LineItems.Select(l => GetStatementLineItemDto.FromLineItem(l)).ToList(),
            };

            return dto;
        }
    }
}
