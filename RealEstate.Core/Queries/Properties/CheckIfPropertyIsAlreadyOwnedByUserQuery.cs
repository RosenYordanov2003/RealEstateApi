namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    public record CheckIfPropertyIsAlreadyOwnedByUserQuery(Guid propertyId, Guid userId) : IRequest<bool>;

}
