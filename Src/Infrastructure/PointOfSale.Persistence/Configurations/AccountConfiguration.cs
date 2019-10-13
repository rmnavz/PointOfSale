using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointOfSale.Domain.Entities;

namespace PointOfSale.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(x => x.ID);

            builder.OwnsOne(x => x.Password);

            builder.HasIndex(x => x.Username).IsUnique();
        }
    }
}
