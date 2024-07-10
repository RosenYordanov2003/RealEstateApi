namespace RealEstate.Core.Commands.Properties
{
    using MediatR;
    using Models.Property;

    public record CreatePropertyCommand(CreatePropertyModel model, Guid ownerId) : IRequest<Guid>;
}
