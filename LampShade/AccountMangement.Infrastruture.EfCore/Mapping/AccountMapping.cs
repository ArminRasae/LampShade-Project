using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.Property(x => x.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.FullName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.ProfilePhoto)
                .HasMaxLength(1000);
           

        }
    }
}
