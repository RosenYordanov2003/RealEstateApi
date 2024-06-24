namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    using Models.Property;

    public record GetUserFavoritePropertiesQuery(Guid userId) : IRequest<IEnumerable<PropertyModel>>;
   
}
