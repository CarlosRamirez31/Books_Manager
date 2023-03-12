using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
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
        private readonly IRepositoryAsync<Author> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IRepositoryAsync<Author> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repositoryAsync.GetByIdAsync(request.AuthorId);
            
            if(author is null)
            {
                throw new KeyNotFoundException("No se encuentra registro");
            }
            else
            {
                author.FirstName = request.FirstName;
                author.LastName = request.LastName;
                author.PhoneNumber = request.PhoneNumber;
                author.Country = request.Country;
                author.Address = request.Address;
                author.City = request.City;

                await _repositoryAsync.UpdateAsync(author);
                return new Response<int>(author.AuthorId);
            }
        }
    }
}
