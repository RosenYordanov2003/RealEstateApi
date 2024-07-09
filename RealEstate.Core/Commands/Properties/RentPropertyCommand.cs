
namespace RealEstate.Core.Commands.Properties
{
    using MediatR;
    using Models.Property;

    public record BookPropertyCommand(BookPropertyModel model, Guid userId) : IRequest;
}
