﻿using Domain.Common;

namespace Domain.Entities
{
    public class Book : AuditBaseEntity
    {
        public Book()
        {
            Comments = new HashSet<Comment>();
        }

        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string BookDescription { get; set; } = null!;
        public int Price { get; set; }
        public DateTime PublicationDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
