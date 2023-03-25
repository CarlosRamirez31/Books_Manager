namespace BooksManager.Core.Domain.Setting
{
    public class JWTSettings
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public double DurationInMinute { get; set; }
    }
}
