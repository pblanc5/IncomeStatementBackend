using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Common
{
    public abstract class AggregateRoot<T> : Entity<T>
    {
        protected AggregateRoot(T id) 
            : base(id) 
        { 
            
        }
    }
}
