using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(e => e.BookDescription)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.CreateBy)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Created).HasColumnType("datetime");

            builder.Property(e => e.LastModified).HasColumnType("datetime");

            builder.Property(e => e.LastModifiedBy)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.PublicationDate).HasColumnType("datetime");

            builder.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false);
        }
    }
}
