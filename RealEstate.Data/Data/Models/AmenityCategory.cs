namespace RealEstate.Data.Data.Models
{
    public class AmenityCategory
    {
        public AmenityCategory()
        {
            Amenities = new HashSet<Amenity>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Amenity> Amenities { get; set; }
    }
}
