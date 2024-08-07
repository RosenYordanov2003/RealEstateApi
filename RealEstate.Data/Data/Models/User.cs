﻿namespace RealEstate.Data.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<Guid>
    {
        public User()
        {
            OwnedProperties = new HashSet<Property>();
            UserFavoriteProperties = new HashSet<UserFavoriteProperties>();
            RentedProperties = new HashSet<PropertiesRents>();
            Subscriptions = new HashSet<Subscription>();
        }
        public ICollection<Property> OwnedProperties { get; set; }
        public ICollection<PropertiesRents> RentedProperties { get; set; }
        public ICollection<UserFavoriteProperties> UserFavoriteProperties { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
