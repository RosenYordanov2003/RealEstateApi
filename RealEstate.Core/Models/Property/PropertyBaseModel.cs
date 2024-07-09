namespace RealEstate.Core.Models.Property
{
    public abstract class PropertyBaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal SquareMeters { get; set; }
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public int BedRoomsCount { get; set; }
        public int BathRoomsCount { get; set; }
    }
}
