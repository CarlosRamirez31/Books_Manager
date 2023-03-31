using BooksManager.Core.Application.Parameters;
using BooksManager.Core.Application.Wrappers;
using Domain.Entities;

namespace BooksManager.Core.Application.Interfaces.Repository
{
    public interface IBookRepository : IGeneryRepository<Book>
    {
        public Task<PageResponse<Book>> ListBook(FilterRequest filter);
    }
}
