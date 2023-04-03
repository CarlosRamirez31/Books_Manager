using BooksManager.Core.Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository;

namespace BooksManager.Infrastructure.Persistece.Repository
{
    public class CommentRepository : GeneryRepository<Comment>, ICommentRepository
    {
        private readonly Books_ManagerContext _context;
        public CommentRepository(Books_ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int bookId)
        {
            return await _context.Set<Comment>().Where(x => x.BookId.Equals(bookId)).ToListAsync();
        }
    }
}
