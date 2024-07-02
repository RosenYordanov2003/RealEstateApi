namespace RealEstate.Core.Commands.Properties
{
    using MediatR;
    public record DeletePropertyCommand(Guid propertyId) : IRequest;
    
}
