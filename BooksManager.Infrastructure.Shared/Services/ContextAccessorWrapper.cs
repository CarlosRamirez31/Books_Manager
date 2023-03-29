using BooksManager.Core.Application.Interfaces.Service;
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
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
