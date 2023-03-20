using Domain.Common;

namespace Domain.Entities
{
    public class Photograph : AuditBaseEntity
    {
        public int PhotographyId { get; set; }
        public string ImagePath { get; set; } = null!;
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
    }
}
