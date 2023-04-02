using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Interfaces.Repository;
using MediatR;
using System.Runtime.InteropServices;

namespace BooksManager.Core.Application.Feautres.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommand : IRequest<Response<int>>
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? BookDescription { get; set; }
        public List<int>? AuthorsIds { get; set; }
        public int? Price { get; set; }
        public DateTime? PublicationDate { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Response<int>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);

            if (book is null)
                throw new KeyNotFoundException($"No existe un libro de id {request.BookId}");

            _mapper.Map(request, book);
            await _bookRepository.UpdateAsync(request.BookId , book);

            return new Response<int>(request.BookId);
        }
    }
}
