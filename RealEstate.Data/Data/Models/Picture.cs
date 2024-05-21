namespace RealEstate.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        public Property Property { get; set; } = null!;

        [Required]
        public string ImgUrl { get; set; } = null!;
    }
}
