using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feautres.Authors.Commands.CreateAuthorCommand
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
        private readonly IRepositoryAsync<Author> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IRepositoryAsync<Author> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request);
            var data = await _repositoryAsync.AddAsync(author);

            return new Response<int>(data.AuthorId);
        }
    }
}
