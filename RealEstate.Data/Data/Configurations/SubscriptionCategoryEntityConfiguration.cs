namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Data.Models;

    public class SubscriptionCategoryEntityConfiguration : IEntityTypeConfiguration<SubscriptionCategory>
    {
        public void Configure(EntityTypeBuilder<SubscriptionCategory> builder)
        {
            builder.HasMany(c => c.Subscriptions)
                 .WithOne(s => s.Category)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(SeedSubscriptionCategories());
        }
        private IEnumerable<SubscriptionCategory> SeedSubscriptionCategories()
        {
            List<SubscriptionCategory> result = new List<SubscriptionCategory>()
            {
                new SubscriptionCategory()
                {
                    Id = 1,
                    Name = "House"
                },
                new SubscriptionCategory()
                {
                    Id = 2,
                    Name = "Тhree-bedroom apartment"
                },
                new SubscriptionCategory()
                {
                    Id = 3,
                    Name = "Тwo-bedroom apartment"
                },
                new SubscriptionCategory()
                {
                    Id = 4,
                    Name = "Four-bedroom apartment"
                },
                new SubscriptionCategory()
                {
                    Id = 5,
                    Name = "Four-bedroom apartment"
                },
                new SubscriptionCategory()
                {
                    Id = 6,
                    Name = "Villa"
                },
                new SubscriptionCategory()
                {
                    Id = 7,
                    Name = "Maisonette"
                }
            };

            return result;
        }
    }
}
