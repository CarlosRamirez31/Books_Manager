using BooksManager.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.Persistece.Context.Configurations
{
    public class BiographyConfiguration : IEntityTypeConfiguration<Biography>
    {
        public void Configure(EntityTypeBuilder<Biography> builder)
        {
                builder.HasNoKey();

                builder.HasIndex(e => e.AuthorId, "UQ__Biograph__70DAFC35F1B34BFC")
                    .IsUnique();

                builder.Property(e => e.BiographyAuthor)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Biography");
        }
    }
}
