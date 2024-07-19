namespace RealEstate.Core.Models.Property
{
    public class PropertyModel : PropertyBaseModel
    {
        public Guid Id { get; set; }
        public string? ImgUrl { get; set; }
        public string City { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
