using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Interfaces.Repository;
using MediatR;

namespace Application.Feautres.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommand : IRequest<Response<int>>
    {
        public int AuthorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }

    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Response<int>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);

            if (author is null) throw new KeyNotFoundException("No se encuentra registro");

            _mapper.Map(request, author);
            await _authorRepository.UpdateAsync(request.AuthorId, author);

            return new Response<int>(request.AuthorId);
        }
    }
}
