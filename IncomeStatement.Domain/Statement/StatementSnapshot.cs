using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Statement
{
    public sealed class StatementSnapshot { 
        public Guid Id { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
}
