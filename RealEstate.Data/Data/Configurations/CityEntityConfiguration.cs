namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(SeedCities());
        }

        private IEnumerable<City> SeedCities()
        {
           List<City> cities = new List<City>()
           {
               new City()
               {
                   Id = 1,
                   Name = "Sofia",
               },
               new City()
               {
                   Id = 2,
                   Name = "Plovdiv",
               },
               new City()
               {
                   Id = 3,
                   Name = "Varna",
               },
               new City()
               {
                   Id = 4,
                   Name = "Burgas",
               }
           };

            return cities;
        }
    }
}
