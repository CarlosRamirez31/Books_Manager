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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(e => e.Content)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.CreateBy)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Created).HasColumnType("datetime");

            builder.Property(e => e.LastModified).HasColumnType("datetime");

            builder.Property(e => e.LastModifiedBy)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.HasOne(d => d.Book)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("PK_Comments");
        }
    }
}
