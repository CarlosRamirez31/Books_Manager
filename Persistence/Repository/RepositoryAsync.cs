using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class RepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T: class
    {
        private readonly Books_ManagerContext _context;

        public RepositoryAsync(Books_ManagerContext context): base(context)
        {
            _context = context;
        }
    }
}
