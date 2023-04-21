using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Dtos.Book;
using BooksManager.Core.Application.Interfaces.Repository;
using BooksManager.Core.Application.Parameters;
using BooksManager.Core.Application.Wrappers;
using MediatR;
using Ubiety.Dns.Core;

namespace BooksManager.Core.Application.Features.Books.Queries.GetFilterBook
{
    public class GetFilterBookQuery : FilterRequest, IRequest<Response<PageResponse<BookResponseDto>>>
    {
    }

    public class GetFilterBookQueryHandler : IRequestHandler<GetFilterBookQuery, Response<PageResponse<BookResponseDto>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetFilterBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Response<PageResponse<BookResponseDto>>> Handle(GetFilterBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.ListBook(request);
            var dto = _mapper.Map<PageResponse<BookResponseDto>>(book);

            return new Response<PageResponse<BookResponseDto>>(dto);
        }
    }
}
