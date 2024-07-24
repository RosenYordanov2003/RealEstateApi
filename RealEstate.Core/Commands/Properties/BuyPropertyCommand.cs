namespace RealEstate.Core.Commands.Properties
{
    using MediatR;
    public record BuyPropertyCommand(Guid propertyId, Guid userId) : IRequest;

}
