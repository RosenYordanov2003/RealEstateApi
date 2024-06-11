﻿namespace RealEstate.Data.Data.Models
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
        [Column(TypeName = "decimal(17, 15)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(17, 15)")]
        public decimal Longitude { get; set; }
        public decimal SquareMeters { get; set; }
        public int FloorNumber { get; set; }
        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int SaleCategoryId { get; set; }
        public SaleCategory Category { get; set; } = null!;
        public decimal Price { get; set; }
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; } = null!;
        [MaxLength(ADDRESS_MAX_LENGTH)]
        [Required]
        public string Address { get; set; } = null!;

        [MaxLength(DESCRIPTION_MAX_LENGTH)]
        public string? Description{ get; set; }

        [ForeignKey(nameof(PropertyCategory))]
        public int PropertyCategoryId { get; set; }
        public PropertyCategory PropertyCategory { get; set; } = null!;

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
