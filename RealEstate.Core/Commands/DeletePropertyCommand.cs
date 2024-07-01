namespace RealEstate.Core.Commands
{
    using MediatR;
    public record DeletePropertyCommand(Guid propertyId) : IRequest
    {
    }
}
