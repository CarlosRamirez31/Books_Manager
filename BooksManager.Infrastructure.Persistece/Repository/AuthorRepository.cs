using BooksManager.Core.Application.Features.Books.Commands.CreateBookCommand;
using BooksManager.Core.Application.Interfaces.Repository;
using BooksManager.Core.Application.Parameters;
using BooksManager.Core.Application.Wrappers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class AuthorRepository : GeneryRepository<Author>, IAuthorRepository
    {
        private readonly Books_ManagerContext _context;

        public AuthorRepository(Books_ManagerContext context): base(context)
        {
            _context = context;
        }

        public async Task<PageResponse<Author>> ListProvider(FilterRequest filter)
        {
            var response = new PageResponse<Author>();
            var author = _context.Set<Author>().AsQueryable().AsNoTracking();

            if (filter.NumFilter is not null && !String.IsNullOrEmpty(filter.TextFilter))
            {
                switch (filter.NumFilter)
                {
                    case 1:
                        author = author.Where(x => x.FirstName.Contains(filter.TextFilter));
                        break;
                    case 2:
                        author = author.Where(x => x.FirstName.Contains(filter.TextFilter));
                        break;
                    case 3:
                        author = author.Where(x => x.Address!.Contains(filter.TextFilter));
                        break;
                    case 4:
                        author = author.Where(x => x.City!.Contains(filter.TextFilter));
                        break;
                    case 5:
                        author = author.Where(x => x.Country!.Contains(filter.TextFilter));
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.StartDate) && !string.IsNullOrEmpty(filter.EndDate))
            {
                author = author.Where(x => x.Created >= Convert.ToDateTime(filter.StartDate)
                && x.Created <= Convert.ToDateTime(filter.EndDate).AddDays(1));
            }

            if (filter.Sort is null) filter.Sort = "AuthorId";

            response.TotalRecords = await author.CountAsync();
            response.Items = await Ordering(filter, author, filter.Download.GetValueOrDefault()).ToListAsync();

            return response;
        }

        public async Task<List<int>> GetIdsAuthorsAsync(CreateBookCommand command)
        {
            var author = GetEntityQuery(x => command.AuthorsIds!.Contains(x.AuthorId))
                .Select(x => x.AuthorId);

            return await author.ToListAsync();
        }
    }
}
