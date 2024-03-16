using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EFCore.Mapping;

public class InventoryMapping : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventory");

        builder.HasKey(x=> x.Id);

        builder.Property(x => x.UnitPrice)
            .HasMaxLength(2000)
            .IsRequired();

        builder.OwnsMany(x => x.Operations, modelBuilder =>
        {
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.ToTable("Operations");
            modelBuilder.Property(x => x.Description)
                .HasMaxLength(2000);
            modelBuilder.WithOwner(x => x.Inventory)
                .HasForeignKey(x => x.InventoryId);

        });
    }
}