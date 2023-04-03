using Application.Wrappers;
using BooksManager.Core.Application.Interfaces.Repository;
using LiteDB;
using MediatR;

namespace BooksManager.Core.Application.Feautres.Comments.Commands.DeleteCommentCommand
{
    public class DeleteCommentCommand : IRequest<Response<int>>
    {
        public int BookId { get; set; }
        public int CommentId { get; set; }
    }

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Response<int>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBookRepository _bookRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository, IBookRepository bookRepository)
        {
            _commentRepository = commentRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Response<int>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book is null)
                throw new KeyNotFoundException($"No existe un libro de id {request.BookId}");

            var comment = await _commentRepository.GetByIdAsync(request.CommentId);
            if (comment is null)
                throw new KeyNotFoundException($"No existe un mentario de id {request.CommentId}");

            await _commentRepository.DeleteAsync(comment);
            return new Response<int>(request.CommentId);
        }
    }
}
