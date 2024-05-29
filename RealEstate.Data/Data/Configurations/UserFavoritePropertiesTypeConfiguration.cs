namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Data.Models;
    public class UserFavoritePropertiesTypeConfiguration : IEntityTypeConfiguration<UserFavoriteProperties>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteProperties> builder)
        {
            builder.HasOne(ufp => ufp.User)
                .WithMany(u => u.UserFavoriteProperties)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ufp => ufp.Property)
                .WithMany(p => p.UserFavoriteProperties)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(ck => new { ck.UserId, ck.PropertyId });
        }
    }
}
