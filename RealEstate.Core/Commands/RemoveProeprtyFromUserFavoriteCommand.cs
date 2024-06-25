namespace RealEstate.Core.Commands
{
    using MediatR;
    using Models.Property;

    public record RemoveProeprtyFromUserFavoriteCommand(AddPropertyToUserFavoritesModel model) : IRequest;
    
}
