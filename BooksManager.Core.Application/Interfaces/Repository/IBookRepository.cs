using BooksManager.Core.Application.Parameters;
using BooksManager.Core.Application.Wrappers;
using Domain.Entities;

namespace BooksManager.Core.Application.Interfaces.Repository
{
    public interface IBookRepository
    {
        public Task<PageResponse<Book>> FilterBook(FilterRequest filter);
    }
}
