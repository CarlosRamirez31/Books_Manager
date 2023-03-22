using BooksManager.Core.Application.Parameters;

namespace BooksManager.Core.Application.Helpers
{
    public static class QueryableHelper
    {
        public static IQueryable<T> Paginte<T>(this IQueryable<T> query, PaginationRequest filter)
        {
            return query.Skip((filter.NumPage - 1) * filter.Records).Take(filter.Records);
        }
    }
}
