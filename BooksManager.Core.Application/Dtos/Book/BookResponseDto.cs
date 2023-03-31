using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Core.Application.Dtos.Book
{
    public class BookResponseDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string BookDescription { get; set; } = null!;
        public int Price { get; set; }
    }
}
