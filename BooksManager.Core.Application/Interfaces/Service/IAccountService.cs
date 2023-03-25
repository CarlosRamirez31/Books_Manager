using Application.Wrappers;
using BooksManager.Core.Application.Dtos.Users;

namespace BooksManager.Core.Application.Interfaces.Service
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
    }
}
