using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using BooksManager.Core.Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Authors.Commands.DeleteAuthorCoomand
{
    public class DeleteAuthorCommand : IRequest<Response<int>>
    {
        public int AuthorId { get; set; }
    }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Response<int>>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Response<int>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);

            if (author is null) throw new KeyNotFoundException("No se encuentran registro");

            await _authorRepository.DeleteAsync(author);
            return new Response<int>(author.AuthorId);
        }
    }
}
