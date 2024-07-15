namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Data.Models;
    public class SalesCategoryEntityConfiguration : IEntityTypeConfiguration<SaleCategory>
    {
        public void Configure(EntityTypeBuilder<SaleCategory> builder)
        {
            builder.HasMany(c => c.Properties)
                .WithOne(p => p.SaleCategory)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(SeedCategories());
        }
        private IEnumerable<SaleCategory> SeedCategories()
        {
            List<SaleCategory> categories = new List<SaleCategory>();

            SaleCategory category1 = new SaleCategory()
            {
                Id = 1,
                Name = "Airbnb",
            };
            SaleCategory category2 = new SaleCategory()
            {
                Id = 2,
                Name = "Sale",
            };

            categories.Add(category1);
            categories.Add(category2);

            return categories;
        }
    }
}
