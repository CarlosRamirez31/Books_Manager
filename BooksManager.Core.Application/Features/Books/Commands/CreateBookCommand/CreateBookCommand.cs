using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;

namespace BooksManager.Core.Application.Features.Books.Commands.CreateBookCommand
{
    public class CreateBookCommand : IRequest<Response<int>>
    {   
        public string? Title { get; set; }
        public string? BookDescription { get; set; }
        public List<int>? AuthorsIds { get; set; }
        public int? Price { get; set; }
        public DateTime? PublicationDate { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Response<int>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepositoy;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepositoy, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepositoy = authorRepositoy;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var ids = await _authorRepositoy.GetIdsAuthorsAsync(request);

            if (request.AuthorsIds!.Count != ids.Count)
                throw new KeyNotFoundException("Uno o mas autores no existe");

            var book = _mapper.Map<Book>(request);
            var data = await _bookRepository.AddAsync(book);

            return new Response<int>(data.BookId);
        }
    }
}
