namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Data.Models;
    public class AmenityCategoryEntityConfiguration : IEntityTypeConfiguration<AmenityCategory>
    {
        public void Configure(EntityTypeBuilder<AmenityCategory> builder)
        {
            builder.HasMany(ac => ac.Amenities)
                .WithOne(a => a.AmenityCategory)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(SeedCategories());
        }
        private IEnumerable<AmenityCategory> SeedCategories()
        {
            return new List<AmenityCategory>()
            {
                new AmenityCategory
                {
                    Id = 1,
                    Name = "School"
                },
                new AmenityCategory
                {
                    Id = 2,
                    Name = "Metro stations"
                }
            };
        }
    }
}
