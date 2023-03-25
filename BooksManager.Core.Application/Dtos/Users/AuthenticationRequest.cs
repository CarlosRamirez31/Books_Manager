namespace BooksManager.Core.Application.Dtos.Users
{
    public class AuthenticationRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
