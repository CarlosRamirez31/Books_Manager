using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Dtos.Book;
using BooksManager.Core.Application.Interfaces.Repository;
using MediatR;
using Ubiety.Dns.Core;

namespace BooksManager.Core.Application.Feautres.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Response<BookResponseDto>>
    {
        public int BookId { get; set; }
    }

    public class GetBookByIdQueryHadler : IRequestHandler<GetBookByIdQuery, Response<BookResponseDto>>
    {
        private readonly IBookRepository _bookRepositoy;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHadler(IBookRepository bookRepositoy, IMapper mapper)
        {
            _bookRepositoy = bookRepositoy;
            _mapper = mapper;
        }

        public async Task<Response<BookResponseDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepositoy.GetByIdAsync(request.BookId);

            if (book is null)
                throw new KeyNotFoundException($"No existe un libro de id {request.BookId}");

            var dto = _mapper.Map<BookResponseDto>(book); 
            return new Response<BookResponseDto>(dto);
        }
    }
}
