namespace RealEstate.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class PropertiesRents
    {
          
        [ForeignKey(nameof(Property))]
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
