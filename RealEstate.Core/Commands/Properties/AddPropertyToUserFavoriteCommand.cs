namespace RealEstate.Core.Commands.Properties
{
    using MediatR;
    using Models.Property;

    public record AddPropertyToUserFavoriteCommand(AddPropertyToUserFavoritesModel model) : IRequest;
}
