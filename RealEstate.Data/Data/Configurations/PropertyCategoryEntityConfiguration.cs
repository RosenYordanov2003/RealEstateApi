namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Data.Models;
    public class PropertyCategoryEntityConfiguration : IEntityTypeConfiguration<PropertyCategory>
    {
        public void Configure(EntityTypeBuilder<PropertyCategory> builder)
        {
            builder.HasMany(c => c.Properties)
               .WithOne(p => p.PropertyCategory)
               .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(SeedCategories());
        }
        private IEnumerable<PropertyCategory> SeedCategories()
        {
            List<PropertyCategory> categories = new List<PropertyCategory>();
            PropertyCategory category1 = new PropertyCategory()
            {
                Id = 1,
                Name = "House",
            };
            PropertyCategory category2 = new PropertyCategory()
            {
                Id = 2,
                Name = "Apartments"
            };
            categories.Add(category1);
            categories.Add(category2);

            return categories;
        }
    }
}
