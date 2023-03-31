using BooksManager.Core.Application.Interfaces.Service;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BooksManager.Infrastructure.Shared.Services
{
    public class ContextAccessorWrapper : IContextAccessorWrapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextAccessorWrapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetContextName()
        {
            var userName = _httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userName == null)
                return "Unknown user";

            return userName;
        }
    }
}
