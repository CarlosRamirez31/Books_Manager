using BooksManager.Core.Application.Feautres.Books.Commands.CreateBookCommand;
using BooksManager.Core.Application.Parameters;
using BooksManager.Core.Application.Wrappers;
using Domain.Entities;

namespace BooksManager.Core.Application.Interfaces.Repository
{
    public interface IAuthorRepository : IGeneryRepository<Author>
    {
        Task<PageResponse<Author>> ListProvider(FilterRequest filter);
        Task<List<int>> GetIdsAuthorsAsync(CreateBookCommand command);
    }
}
