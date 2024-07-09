namespace RealEstate.Core.Models.Property
{
    public class BookPropertyModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Category { get; set; } = null!;
    }
}
