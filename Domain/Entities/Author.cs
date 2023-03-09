using Domain.Common;

namespace Domain.Entities
{
    public class Author : AuditBaseEntity
    {
        public Author()
        {
            Photographs = new HashSet<Photograph>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        public virtual ICollection<Photograph> Photographs { get; set; }
    }
}
