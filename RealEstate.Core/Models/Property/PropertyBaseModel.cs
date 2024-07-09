namespace RealEstate.Core.Models.Property
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.PropertyValidation;
    public abstract class PropertyBaseModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;
        public decimal SquareMeters { get; set; }

        [MaxLength(ADDRESS_MAX_LENGTH)]
        [Required]
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public int BedRoomsCount { get; set; }
        public int BathRoomsCount { get; set; }
    }
}
