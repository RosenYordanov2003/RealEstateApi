namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.RentedProperties)
                .WithOne(p => p.Renter)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.OwnedProperties)
                .WithOne(p => p.Owner)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
