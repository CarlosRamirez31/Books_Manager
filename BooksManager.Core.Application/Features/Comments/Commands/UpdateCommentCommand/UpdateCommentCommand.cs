using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Interfaces.Repository;
using MediatR;

namespace BooksManager.Core.Application.Features.Comments.Commands.UpdateCommentCommand
{
    public class UpdateCommentCommand : IRequest<Response<int>>
    {
        public int BookId { get; set; }
        public int CommentId { get; set; }
        public string? Content { get; set; }
    }

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Response<int>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book is null)
                throw new KeyNotFoundException($"No existe un libro de id {request.BookId}");

            var comment = await _commentRepository.GetByIdAsync(request.CommentId);
            if (comment is null)
                throw new KeyNotFoundException($"No existe un comentario de id {request.CommentId}");

            _mapper.Map(request, comment);
            await _commentRepository.UpdateAsync(request.CommentId, comment);

            return new Response<int>(request.CommentId);
        }
    }
}
