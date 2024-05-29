namespace RealEstate.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.PropertyCategoryValidation;
    public class PropertyCategory
    {
        public PropertyCategory()
        {
            Properties = new List<Property>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;
        public ICollection<Property> Properties { get; set; }
    }
}
