namespace RealEstate.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class Subscription
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
