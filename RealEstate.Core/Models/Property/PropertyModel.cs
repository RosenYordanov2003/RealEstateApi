namespace RealEstate.Core.Models.Property
{
    public class PropertyModel : PropertyBaseModel
    {
        public string? ImgUrl { get; set; }
        public string City { get; set; } = null!;
    }
}
