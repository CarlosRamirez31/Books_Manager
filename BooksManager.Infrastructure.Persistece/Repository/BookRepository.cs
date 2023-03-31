using BooksManager.Core.Application.Interfaces.Repository;
using BooksManager.Core.Application.Parameters;
using BooksManager.Core.Application.Wrappers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository;

namespace BooksManager.Infrastructure.Persistece.Repository
{
    public class BookRepository : GeneryRepository<Book>, IBookRepository
    {
        private readonly Books_ManagerContext _context;

        public BookRepository(Books_ManagerContext context): base(context)
        {
            _context = context;
        }

        public async Task<PageResponse<Book>> FilterBook(FilterRequest filter)
        {
            var response = new PageResponse<Book>();
            var book = _context.Set<Book>().AsQueryable();
            
            if(filter.NumFilter is not null && !String.IsNullOrEmpty(filter.TextFilter))
            {
                switch(filter.NumFilter)
                {
                    case 1:
                        book = book.Where(x => x.Title.Contains(filter.TextFilter));
                        break;
                    case 2:
                        book = book.Where(x => x.BookDescription.Contains(filter.TextFilter));
                        break;
                }
            }

            if(!String.IsNullOrEmpty(filter.StartDate) && !String.IsNullOrEmpty(filter.EndDate))
            {
                book = book.Where(x => x.Created >= Convert.ToDateTime(filter.StartDate) &&
                x.LastModified <= Convert.ToDateTime(filter.EndDate).AddDays(1));
            }

            response.TotalRecords = await book.CountAsync();
            response.Items = await Ordering(filter, book, filter.Download.GetValueOrDefault()).ToListAsync();
            return response;
        }
    }
}
