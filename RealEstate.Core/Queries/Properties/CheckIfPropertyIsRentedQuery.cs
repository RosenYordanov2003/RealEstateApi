namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    using Models.Property;
    public record CheckIfPropertyIsRentedQuery(PropertyRentModel model) : IRequest<bool>;
}
