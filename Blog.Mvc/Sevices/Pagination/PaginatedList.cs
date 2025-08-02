using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Blog.Mvc.Sevices.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public PaginatedList(List<T> items, int pageIndex, int count, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);

        }
        public bool HasPrevious => PageIndex > 1;
        public bool HasNext => PageIndex < TotalPages;
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, pageIndex, count, pageSize);
        }

        internal static async Task<string?> CreateAsync(IAsyncQueryProvider blogs, int v, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
