namespace RealEstate.Data.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<Guid>
    {
        public User()
        {
            OwnedProperties = new HashSet<Property>();
            UserFavoriteProperties = new HashSet<UserFavoriteProperties>();
        }
        public ICollection<Property> OwnedProperties { get; set; }
        public ICollection<UserFavoriteProperties> UserFavoriteProperties { get; set; }
    }
}
