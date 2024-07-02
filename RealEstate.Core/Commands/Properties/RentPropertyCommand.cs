
namespace RealEstate.Core.Commands.Properties
{
    using MediatR;
    using Models.Property;

    public record RentPropertyCommand(PropertyRentModel model, Guid userId) : IRequest;
}
