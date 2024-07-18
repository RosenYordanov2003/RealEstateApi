namespace RealEstate.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.AmenityValidation;
    public class AmenityCategory
    {
        public AmenityCategory()
        {
            Amenities = new HashSet<Amenity>();
        }
        public int Id { get; set; }
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;
        public ICollection<Amenity> Amenities { get; set; }
    }
}
