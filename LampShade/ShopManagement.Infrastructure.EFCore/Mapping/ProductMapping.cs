using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>

    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreationDate);

            builder.Property(x => x.Name)
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.Code)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .HasMaxLength(400);

            builder.Property(x => x.IsInStock);

            builder.Property(x => x.ShortDescription)
                .IsRequired();

            builder.Property(x => x.Picture)
                .HasMaxLength(2000);

            builder.Property(x => x.PictureAlt)
                .HasMaxLength(500);

            builder.Property(x => x.PictureTitle)
                .HasMaxLength(500);

            builder.Property(x => x.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.Slug)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Keywords)
                .HasMaxLength(200)
                .IsRequired(
                    );
            builder.Property(x => x.MetaDescription)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.ProductPictures)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);


        }
    }
}
