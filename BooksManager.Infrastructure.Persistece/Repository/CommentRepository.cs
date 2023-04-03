using BooksManager.Core.Application.Interfaces.Repository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repository;

namespace BooksManager.Infrastructure.Persistece.Repository
{
    public class CommentRepository : GeneryRepository<Comment>, ICommentRepository
    {
        public CommentRepository(Books_ManagerContext context): base(context)
        {
        }
    }
}
