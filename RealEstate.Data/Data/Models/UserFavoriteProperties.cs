namespace RealEstate.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class UserFavoriteProperties
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        public Property Property { get; set; } = null!;
    }
}
