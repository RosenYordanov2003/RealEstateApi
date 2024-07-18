namespace RealEstate.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.EntityValidation.SubscriptionValidation;
    public class SubscriptionCategory
    {
        public SubscriptionCategory()
        {
            Subscriptions = new List<Subscription>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
