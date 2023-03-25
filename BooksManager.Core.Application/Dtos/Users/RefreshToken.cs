using Org.BouncyCastle.Bcpg.OpenPgp;

namespace BooksManager.Core.Application.Dtos.Users
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.Now >= Expires;
        public DateTime Created { get; set; }
        public string? CreateByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplaceByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired; 
    }
}
