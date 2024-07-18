namespace RealEstate.Core.Commands.Subscription
{
    using MediatR;
    using Models.Subscription;
    public record CreateSubscriptionCommand(SubscriptionModel model, Guid userId) : IRequest;
}
