namespace RealEstate.Core.Commands
{
    using MediatR;
    using Models.Property;

    public record AddPropertyToUserFavoriteCommand(AddPropertyToUserFavoritesModel model) : IRequest;
}
