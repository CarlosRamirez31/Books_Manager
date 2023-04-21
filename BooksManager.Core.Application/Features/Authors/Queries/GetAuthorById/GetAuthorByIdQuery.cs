using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Dtos.Author;
using BooksManager.Core.Application.Interfaces.Repository;
using MediatR;

namespace BooksManager.Core.Application.Features.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<Response<AuthorResponseDto>>
    {
        public int AuthorId { get; set; }

    }
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Response<AuthorResponseDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Response<AuthorResponseDto>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);

            if (author is null) throw new KeyNotFoundException("No se ha encontrado registro");

            var dto = _mapper.Map<AuthorResponseDto>(author);
            return new Response<AuthorResponseDto>(dto);
        }
    }
}
