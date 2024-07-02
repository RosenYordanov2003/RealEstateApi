namespace RealEstate.Core.Commands.Properties
{
    using MediatR;
    using Models.Property;

    public record RemoveProeprtyFromUserFavoriteCommand(AddPropertyToUserFavoritesModel model) : IRequest;

}
