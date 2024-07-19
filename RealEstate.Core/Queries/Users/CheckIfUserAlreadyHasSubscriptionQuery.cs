namespace RealEstate.Core.Queries.Users
{
    using MediatR;
    public record CheckIfUserAlreadyHasSubscriptionQuery(Guid userId, int propertyCategoryId) : IRequest<bool>;
    
}
