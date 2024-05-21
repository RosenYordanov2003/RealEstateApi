namespace RealEstate.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static GlobalConstants.EntityValidation.PropertyValidation;

    public class Property
    {
        public Property()
        {
            Pictures = new HashSet<Picture>();
            UserFavoriteProperties = new HashSet<UserFavoriteProperties>();
            Rents = new HashSet<PropertiesRents>();
        }
        [Key]
        public Guid Id { get; set; }
        public int BedRoomsCount { get; set; }
        public int BathRoomsCount { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public decimal Price { get; set; }
        [MaxLength(CITY_MAX_LENGTH)]
        public string City { get; set; } = null!;
        [MaxLength(ADDRESS_MAX_LENGTH)]
        public string Address { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public User Owner { get; set; } = null!;

        [ForeignKey(nameof(Renter))]
        public Guid? RenterId { get; set; }
        public User? Renter { get; set; }
        public ICollection<UserFavoriteProperties> UserFavoriteProperties { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<PropertiesRents> Rents { get; set; }
    }
}
