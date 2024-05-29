namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Data.Models;
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Properties)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
