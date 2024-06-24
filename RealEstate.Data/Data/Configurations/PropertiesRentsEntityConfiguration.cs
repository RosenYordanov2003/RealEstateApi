namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    internal class PropertiesRentsEntityConfiguration : IEntityTypeConfiguration<PropertiesRents>
    {
        public void Configure(EntityTypeBuilder<PropertiesRents> builder)
        {
            builder.HasOne(pr => pr.User)
                .WithMany(u => u.RentedProperties)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pr => pr.Property)
                .WithMany(p => p.PropertiesRents)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(ck => new { ck.UserId, ck.PropertyId });
        }
    }
}
