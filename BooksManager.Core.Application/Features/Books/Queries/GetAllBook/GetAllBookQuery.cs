using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Dtos.Book;
using BooksManager.Core.Application.Interfaces.Repository;
using MediatR;

namespace BooksManager.Core.Application.Features.Books.Queries.GetAllBook
{
    public class GetAllBookQuery : IRequest<Response<List<BookResponseDto>>>
    {
    }

    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, Response<List<BookResponseDto>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<BookResponseDto>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAllAsync();
            var dto = _mapper.Map<List<BookResponseDto>>(book);

            return new Response<List<BookResponseDto>>(dto);
        }
    }
}
