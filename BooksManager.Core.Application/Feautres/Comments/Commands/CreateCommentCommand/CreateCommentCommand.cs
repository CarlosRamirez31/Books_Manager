using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;

namespace BooksManager.Core.Application.Feautres.Comments.Commands.CreateCommentCommand
{
    public class CreateCommentCommand : IRequest<Response<int>>
    {
        public int BookId { get; set; }
        public string Content { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Response<int>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book is null)
                throw new KeyNotFoundException($"No existe un libro de id {request.BookId}");

            var comment = _mapper.Map<Comment>(request);
            var data = await _commentRepository.AddAsync(comment);

            return new Response<int>(data.CommentId);
        }
    }

}
