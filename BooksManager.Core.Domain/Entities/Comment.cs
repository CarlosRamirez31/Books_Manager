using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Comment : AuditBaseEntity
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = null!;
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!;
    }
}
