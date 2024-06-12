namespace RealEstate.Core.Models.Property
{
    public class PropertyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal SquareMeters { get; set; }
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }
    }
}
