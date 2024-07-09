namespace RealEstate.Core.Models.Property
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.PropertyValidation;
    public class EditPropertyModel : PropertyBaseModel
    {
        public int CityId { get; set; }
        [MaxLength(DESCRIPTION_MAX_LENGTH)]
        public string? Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        [Range(minimum: PROPERTY_MIN_FLOOR_VALUE, maximum: PROPERTY_MAX_FLOOR_VALUE)]
        public int FloorNumber { get; set; }
        public int SaleCategoryId { get; set; }
        public int PropertyCategoryId { get; set; }
    }
}
