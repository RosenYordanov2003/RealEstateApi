namespace RealEstate.Data.Data.Models
{
    using NetTopologySuite.Geometries;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Amenity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public Point Location { get; set; } = null!;

        [ForeignKey(nameof(AmenityCategory))]
        public int AmenityCategoryId { get; set; }
        public AmenityCategory AmenityCategory { get; set; } = null!;
    }
}
