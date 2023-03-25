using BooksManager.Core.Application.Helpers;
using BooksManager.Core.Application.Interfaces.Repository;
using BooksManager.Core.Application.Parameters;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Persistence.Repository
{
    public class GeneryRepository<T> : IGeneryRepository<T> where T : class
    {
        private readonly Books_ManagerContext _context;

        public GeneryRepository(Books_ManagerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var entry = await _context.Set<T>().FindAsync(id);
            _context.Entry(entry!).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter is not null) query = query.Where(filter);

            return query;
        }

        public IQueryable<TD> Ordering<TD>(PaginationRequest request, IQueryable<TD> queryable, bool pagination = false)
            where TD : class
        {
            IQueryable<TD> queryDto = (request.Order == "desc") ? queryable.OrderBy($"{request.Sort} descending") :
                queryable.OrderBy($"{request.Sort} ascending");

            if (!pagination) queryDto = queryDto.Paginate(request);

            return queryDto;
        }
    }
}
