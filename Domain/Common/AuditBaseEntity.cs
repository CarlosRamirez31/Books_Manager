namespace Domain.Common
{
    public class AuditBaseEntity
    {
        public int Id { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
