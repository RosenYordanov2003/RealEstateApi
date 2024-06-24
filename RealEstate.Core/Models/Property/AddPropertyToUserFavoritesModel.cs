namespace RealEstate.Core.Models.Property
{
    public class AddPropertyToUserFavoritesModel
    {
        public AddPropertyToUserFavoritesModel(Guid userId, Guid propertyId)
        {
            UserId = userId;
            PropertyId = propertyId;
        }

        public Guid UserId { get; set; }
        public Guid PropertyId { get; set; }
    }
}
