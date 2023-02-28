using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Statement.Errors
{
    public class LineItemTypeNotSetException : Exception
    {
        public LineItemTypeNotSetException()
        {
        }

        public LineItemTypeNotSetException(string message)
            : base(message)
        {
        }

        public LineItemTypeNotSetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
