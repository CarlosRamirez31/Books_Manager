using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Dtos.Comment;
using BooksManager.Core.Application.Interfaces.Repository;
using MediatR;
using Ubiety.Dns.Core;

namespace BooksManager.Core.Application.Features.Comments.Queries.GetCommentByBookId
{
    public class GetCommentByBookIdQuery : IRequest<Response<List<CommentResponseDto>>>
    {
        public int BookId { get; set; }
    }

    public class GetCommentByBookIdQueryHandler : IRequestHandler<GetCommentByBookIdQuery, Response<List<CommentResponseDto>>>
    {
        private readonly ICommentRepository _commentReposiory;
        private readonly IMapper _mapper;

        public GetCommentByBookIdQueryHandler(ICommentRepository commentReposiory, IMapper mapper)
        {
            _commentReposiory = commentReposiory;
            _mapper = mapper;
        }

        public async Task<Response<List<CommentResponseDto>>> Handle(GetCommentByBookIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentReposiory.GetCommentsAsync(request.BookId);

            var dto = _mapper.Map<List<CommentResponseDto>>(comments);

            return new Response<List<CommentResponseDto>>(dto);
        }
    }
}
