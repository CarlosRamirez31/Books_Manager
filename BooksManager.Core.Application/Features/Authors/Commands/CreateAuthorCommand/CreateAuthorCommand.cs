using Application.Wrappers;
using AutoMapper;
using BooksManager.Core.Application.Interfaces.Repository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Authors.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<Response<int>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Response<int>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request);
            var data = await _authorRepository.AddAsync(author);

            return new Response<int>(data.AuthorId);
        }
    }
}
