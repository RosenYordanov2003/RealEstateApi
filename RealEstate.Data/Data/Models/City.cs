namespace RealEstate.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.PropertyValidation;
    public class City
    {
        public City()
        {
            Properties = new HashSet<Property>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(CITY_MAX_LENGTH)]
        public string Name { get; set; } = null!;
        public ICollection<Property> Properties { get; set; }
    }
}
