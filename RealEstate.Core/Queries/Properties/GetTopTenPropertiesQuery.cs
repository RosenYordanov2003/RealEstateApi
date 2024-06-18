namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    using Models.Property;

    public record GetTopTenPropertiesQuery(string propertyCategory, string salesCateogry) : IRequest<IEnumerable<PropertyModel>>;
}
