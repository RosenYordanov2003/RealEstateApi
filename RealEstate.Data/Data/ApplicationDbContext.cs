namespace RealEstate.Data.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Configurations;
    using Models;

    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<SaleCategory> SaleCategories { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PropertiesRents> PropertiesRents { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<UserFavoriteProperties> UsersFavoriteProperties { get; set; }
        public DbSet<PropertyCategory> PropertyCategories { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserEntityTypeConfiguration());
            builder.ApplyConfiguration(new UserFavoritePropertiesTypeConfiguration());
            builder.ApplyConfiguration(new SalesCategoryEntityConfiguration());
            builder.ApplyConfiguration(new PictureEntityConfiguration());
            builder.ApplyConfiguration(new PropertyCategoryEntityConfiguration());
            builder.ApplyConfiguration(new CityEntityConfiguration());
            builder.ApplyConfiguration(new PropertyEntityConfiguration());
            builder.ApplyConfiguration(new PropertiesRentsEntityConfiguration());
        }
    }
}
