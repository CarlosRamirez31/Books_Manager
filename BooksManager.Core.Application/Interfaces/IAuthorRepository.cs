using Application.Interfaces;
using BooksManager.Core.Application.Parameters;
using BooksManager.Core.Application.Wrappers;
using Domain.Entities;

namespace BooksManager.Core.Application.Interfaces
{
    public interface IAuthorRepository : IGeneryRepository<Author>
    {
        Task<PageResponse<Author>> ListProvider(FilterRequest filter);
    }
}
