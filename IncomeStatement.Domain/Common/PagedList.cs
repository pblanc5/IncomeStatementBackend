using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Domain.Common;

public class PagedList<T> : List<T>
{
    public int CurrentPage { get; private set; } = 1;
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; } = 10;
    public int TotalCount { get; private set; }
    public int Offset => (CurrentPage - 1) * PageSize;
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PagedList(List<T> list, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(list);
    }

    public PagedList(int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    public void SetCount(int count)
    {
        TotalCount = count;
        TotalPages = (int)Math.Ceiling(count / (double)PageSize);
    }
}
