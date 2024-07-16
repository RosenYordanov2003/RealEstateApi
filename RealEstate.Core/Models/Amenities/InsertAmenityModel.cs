namespace RealEstate.Core.Models.Amenities
{
    using System.ComponentModel.DataAnnotations;
    public class InsertAmenityModel
    {
        [Required]
        public string Name { get; set; } = null!;

        public double Latitude {  get; set; }
        public double Longitude {  get; set; }
    }
}
