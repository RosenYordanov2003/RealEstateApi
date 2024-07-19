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

            builder.HasMany(c => c.Subscriptions)
                .WithOne(s => s.Category)
                .OnDelete(DeleteBehavior.NoAction);
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
                Name = "Тhree-bedroom apartment"
            };
            PropertyCategory category3 = new PropertyCategory()
            {
                Id = 3,
                Name = "Two-bedroom apartment"
            };
            PropertyCategory category4 = new PropertyCategory()
            {
                Id = 4,
                Name = "Four-bedroom apartment"
            };
            PropertyCategory category5 = new PropertyCategory()
            {
                Id = 5,
                Name = "One-bedroom apartment"
            };
            PropertyCategory category6 = new PropertyCategory()
            {
                Id = 6,
                Name = "Maisonette"
            };
            PropertyCategory category7 = new PropertyCategory()
            {
                Id = 7,
                Name = "Villa"
            };
            categories.Add(category1);
            categories.Add(category2);
            categories.Add(category3);
            categories.Add(category4);
            categories.Add(category5);
            categories.Add(category6);
            categories.Add(category7);

            return categories;
        }
    }
}
