namespace RealEstate.Core.Models.Property
{
    using Pictures;

    public class PropertyDetailsModel : PropertyBaseModel
    {
        public PropertyDetailsModel()
        {
            Pictures = new List<PictureModel>();
        }
        public IEnumerable<PictureModel> Pictures { get; set; }
        public string? Description { get; set; }
        public int BedRoomsCount { get; set; }
        public int BathRoomsCount { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
