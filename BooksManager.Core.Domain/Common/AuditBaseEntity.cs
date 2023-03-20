namespace Domain.Common
{
    public class AuditBaseEntity
    {
        public string? CreateBy { get; set; }
        public DateTime? Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
