using Domain.Entities;

namespace BooksManager.Core.Application.Interfaces.Repository
{
    public interface ICommentRepository : IGeneryRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsAsync(int bookId);
    }
}
