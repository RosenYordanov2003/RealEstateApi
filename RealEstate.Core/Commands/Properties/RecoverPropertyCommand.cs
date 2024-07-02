namespace RealEstate.Core.Commands.Properties
{
    using MediatR;
    public record RecoverPropertyCommand(Guid propertyId) : IRequest;
   
}
