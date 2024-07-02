namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    public record CheckPropertyCategoryQuery(Guid propertyId) : IRequest<bool>;

}
