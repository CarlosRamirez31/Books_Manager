using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(e => e.Address)
                .HasMaxLength(120)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Country)
                .HasMaxLength(90)
                .IsUnicode(false);

            builder.Property(e => e.CreateBy)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Created).HasColumnType("datetime");

            builder.Property(e => e.FirstName)
                .HasMaxLength(120)
                .IsUnicode(false);

            builder.Property(e => e.LastModified).HasColumnType("datetime");

            builder.Property(e => e.LastModifiedBy)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .HasMaxLength(120)
                .IsUnicode(false);
        }
    }
}
