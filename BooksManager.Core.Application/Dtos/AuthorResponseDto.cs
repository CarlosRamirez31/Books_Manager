using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Core.Application.Dtos
{
    public class AuthorResponseDto
    {
        public int AuthorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime? Created { get; set; }
    }
}
