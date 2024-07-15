namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    using Models.Property;

    public record GetPropertiesNearby5KmQuery(double latitude, double longitude) : IRequest<IEnumerable<PropertyModel>>;
   
}
