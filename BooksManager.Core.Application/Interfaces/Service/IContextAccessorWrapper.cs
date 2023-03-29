using Microsoft.AspNetCore.Http;

namespace BooksManager.Core.Application.Interfaces.Service
{
    public interface IContextAccessorWrapper
    {
        string GetContextName();
    }
}
