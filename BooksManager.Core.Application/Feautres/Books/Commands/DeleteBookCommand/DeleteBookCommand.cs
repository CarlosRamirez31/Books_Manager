using Application.Wrappers;
using BooksManager.Core.Application.Interfaces.Repository;
using MediatR;

namespace BooksManager.Core.Application.Feautres.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommand : IRequest<Response<int>>
    {
        public int BookId { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Response<int>>
    {
        private readonly IBookRepository _bookRepositoy;

        public DeleteBookCommandHandler(IBookRepository bookRepositoy)
        {
            _bookRepositoy = bookRepositoy;
        }

        public async Task<Response<int>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepositoy.GetByIdAsync(request.BookId);

            if (book is null)
                throw new KeyNotFoundException($"No existe un libro con el id {book!.BookId}");

            await _bookRepositoy.DeleteAsync(book);
            return new Response<int>(request.BookId);
        }
    }
}
