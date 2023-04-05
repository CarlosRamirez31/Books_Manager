using System;
using System.Collections.Generic;

namespace BooksManager.Core.Domain.Entities
{
    public partial class Biography
    {
        public int AuthorId { get; set; }
        public string? BiographyAuthor { get; set; }
    }
}
