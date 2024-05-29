namespace RealEstate.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RealEstate.Data.Data.Models;
    public class PictureEntityConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasOne(p => p.Property)
                .WithMany(p => p.Pictures)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
