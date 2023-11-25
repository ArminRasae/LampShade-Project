using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Picture)
                .HasMaxLength(10000)
                .IsRequired();
            
            builder.Property(x => x.PictureAlt)
                .HasMaxLength(600)
                .IsRequired();

            builder.Property(x => x.PictureTitle)
                .HasMaxLength(600)
                .IsRequired();


            builder.Property(x => x.IsRemoved);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductPictures)
                .HasForeignKey(x => x.ProductId);



        }
    }
}
