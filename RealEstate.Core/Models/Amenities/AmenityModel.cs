namespace RealEstate.Core.Models.Amenities
{
    public class AmenityModel
    {
        public string Name { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }
    }
}
