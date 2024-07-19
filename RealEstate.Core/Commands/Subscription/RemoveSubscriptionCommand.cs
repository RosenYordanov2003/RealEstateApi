
namespace RealEstate.Core.Commands.Subscription
{
    using MediatR;
    public record RemoveSubscriptionCommand(Guid userId, int categoryId) : IRequest;
}
