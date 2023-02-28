using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Statement.Errors
{
    public sealed class LineItemNotFoundException : Exception
    {
        public LineItemNotFoundException()
        {
        }

        public LineItemNotFoundException(string message)
            : base(message)
        {
        }

        public LineItemNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
