using BooksManager.Core.Application.Interfaces;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repository
{
    public class AuthorRepository : GeneryRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(Books_ManagerContext context) : base(context) { }
    }
}
