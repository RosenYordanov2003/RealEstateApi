namespace RealEstate.Data.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<Guid>
    {
        public User()
        {
            OwnedProperties = new HashSet<Property>();
            UserFavoriteProperties = new HashSet<UserFavoriteProperties>();
            RentedProperties = new HashSet<Property>();
        }
        public ICollection<Property> OwnedProperties { get; set; }
        public ICollection<Property> RentedProperties { get; set; }
        public ICollection<UserFavoriteProperties> UserFavoriteProperties { get; set; }
    }
}
