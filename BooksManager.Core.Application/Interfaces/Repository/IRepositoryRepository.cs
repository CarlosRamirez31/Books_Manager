using BooksManager.Core.Application.Parameters;
using System.Linq.Expressions;

namespace BooksManager.Core.Application.Interfaces.Repository
{
    public interface IGeneryRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter);
        IQueryable<TD> Ordering<TD>(PaginationRequest filter, IQueryable<TD> queryable, bool pagination = false)
            where TD : class;
    }
}
