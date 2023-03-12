using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
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
        private readonly IRepositoryAsync<Author> _repositoryAsync;

        public DeleteAuthorCommandHandler(IRepositoryAsync<Author> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repositoryAsync.GetByIdAsync(request.AuthorId);

            if(author is null)
            {
                throw new KeyNotFoundException("No se encuentran registro");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(author);
                return new Response<int>(author.AuthorId);
            }
        }
    }
}
