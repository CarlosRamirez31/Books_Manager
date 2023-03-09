using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Context.Configurations
{
    internal class PhotographConfiguration : IEntityTypeConfiguration<Photograph>
    {
        public void Configure(EntityTypeBuilder<Photograph> builder)
        {
            builder.HasKey(e => e.PhotographyId)
                .HasName("PK__Photogra__1AA62B4A72260A34");

            builder.Property(e => e.CreateBy)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Created).HasColumnType("datetime");

            builder.Property(e => e.ImagePath)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Image_Path");

            builder.Property(e => e.LastModified).HasColumnType("datetime");

            builder.Property(e => e.LastModifiedBy)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.HasOne(d => d.Author)
                .WithMany(p => p.Photographs)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("PK_Photographs");
        }
    }
}
