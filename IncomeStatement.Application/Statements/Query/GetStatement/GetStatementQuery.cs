using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.Statements.Query.GetStatement
{
    public class GetStatementQuery : IRequest<GetStatementDto>
    {
        public int Year { get; set; }
        public int? Month { get; set; }
    }
}
