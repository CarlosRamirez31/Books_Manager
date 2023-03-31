using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context.Configurations
{
    public class AuthorsBookConfiguration : IEntityTypeConfiguration<AuthorsBook>
    {
        public void Configure(EntityTypeBuilder<AuthorsBook> builder)
        {
            builder.HasKey(x => new {x.AuthorId, x.BookId});
        }
    }
}
