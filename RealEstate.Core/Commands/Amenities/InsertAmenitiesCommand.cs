
namespace RealEstate.Core.Commands.Amenities
{
    using MediatR;
    public record InsertAmenitiesCommand(string filePath, int amenityCateogryId) : IRequest;

}
