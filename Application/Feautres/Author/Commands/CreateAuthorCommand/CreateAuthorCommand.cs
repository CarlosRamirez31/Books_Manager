using Application.Wrappers;
using MediatR;

namespace Application.Feautres.Author.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Response<int>>
{
        public async Task<Response<int>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
