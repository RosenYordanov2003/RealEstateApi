namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    using Models.Property;

    public record GetPropertiesNearby20Km(double latitude, double longitude) : IRequest<IEnumerable<PropertyModel>>;
   
}
