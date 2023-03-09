using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context.Configurations
{
    public class AuthorsBookConfiguration : IEntityTypeConfiguration<AuthorsBook>
    {
        public void Configure(EntityTypeBuilder<AuthorsBook> builder)
        {
            builder.HasNoKey();

            builder.HasOne(d => d.Author)
                .WithMany()
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_AuthorsBooks");

            builder.HasOne(d => d.Book)
                .WithMany()
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_BooksAuthors");
        }
    }
}
