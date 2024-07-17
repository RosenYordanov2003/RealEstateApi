namespace RealEstate.Core.Models.Property
{
    using Pictures;
    using Core.Models.Amenities;

    public class PropertyDetailsModel : PropertyModel
    {
        public PropertyDetailsModel()
        {
            Pictures = new List<PictureModel>();
            Amenities = new List<AmenityModel>();
        }
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IEnumerable<PictureModel> Pictures { get; set; }
        public IEnumerable<AmenityModel> Amenities { get; set; }
    }
}
