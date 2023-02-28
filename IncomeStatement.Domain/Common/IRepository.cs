using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Common
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>?> ListAsync(int offset, int limit);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(Guid id);
    }
}
