namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.RentedProperties)
                .WithOne(p => p.Renter)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.OwnedProperties)
                .WithOne(p => p.Owner)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(SeedUsers());
        }

        private IEnumerable<User> SeedUsers()
        {
            List<User> users = new List<User>();
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            User userOne = new User()
            {
                Id = Guid.Parse("E7D6EE68-2A6D-4A1A-B640-B26FCEB74254"),
                UserName = "Bobi",
                NormalizedUserName = "BOBI",
                Email = "bobi123@gmail.com",
                NormalizedEmail = "BOBI123@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            userOne.PasswordHash = passwordHasher.HashPassword(userOne, "test12345");
            users.Add(userOne);

            return users;
        }
    }
}
