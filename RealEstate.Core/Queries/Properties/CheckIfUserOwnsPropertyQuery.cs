namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    public record CheckIfUserOwnsPropertyQuery(Guid userId, Guid propertyId) : IRequest<bool>;
   
}
