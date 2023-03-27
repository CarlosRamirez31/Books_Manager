using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Dtos.Users;
using BooksManager.Core.Application.Interfaces.Repository;
using BooksManager.Core.Application.Parameters;
using BooksManager.Core.Application.Wrappers;
using MediatR;

namespace BooksManager.Core.Application.Feautres.Authors.Queries.GetAllAuthor
{
    public class GetAllAuthorQuery : FilterRequest, IRequest<Response<PageResponse<AuthorResponseDto>>>
    {
    }

    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, Response<PageResponse<AuthorResponseDto>>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Response<PageResponse<AuthorResponseDto>>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.ListProvider(request);
            var dto = _mapper.Map<PageResponse<AuthorResponseDto>>(author);

            return new Response<PageResponse<AuthorResponseDto>>(dto);
        }
    }
}
