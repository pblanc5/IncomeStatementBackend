using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Application.Statements.Command.CreateStatement
{
    public sealed class CreateStatementCommand : IRequest<int>
    {
        public short Year { get; set; }
        public short Month { get; set; }
    }
}
