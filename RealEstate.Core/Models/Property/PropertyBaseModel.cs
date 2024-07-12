namespace RealEstate.Core.Models.Property
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.PropertyValidation;
    public abstract class PropertyBaseModel
    {

        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;
        public decimal SquareMeters { get; set; }

        [MaxLength(ADDRESS_MAX_LENGTH)]
        [Required]
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        [Range(minimum: BEDROOM_MIN_VALUE, maximum: BEDROOM_MAX_VALUE)]
        public int BedRoomsCount { get; set; }
        [Range(minimum: BATHROOM_MIN_VALUE, maximum: BATHROOM_MAX_VALUE)]
        public int BathRoomsCount { get; set; }
    }
}
