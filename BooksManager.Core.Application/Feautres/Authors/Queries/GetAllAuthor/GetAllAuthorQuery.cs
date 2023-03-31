using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Dtos.Author;
using BooksManager.Core.Application.Interfaces.Repository;
using MediatR;
using MongoDB.Driver;
using Ubiety.Dns.Core;

namespace BooksManager.Core.Application.Feautres.Authors.Queries.GetAllAuthor
{
    public class GetAllAuthorQuery : IRequest<Response<List<AuthorResponseDto>>>
    {
    }

    public class GetAllAuthorCommandHandler : IRequestHandler<GetAllAuthorQuery, Response<List<AuthorResponseDto>>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<AuthorResponseDto>>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAllAsync();
            var dto = _mapper.Map<List<AuthorResponseDto>>(author);

            return new Response<List<AuthorResponseDto>>(dto);
        }
    }
}
