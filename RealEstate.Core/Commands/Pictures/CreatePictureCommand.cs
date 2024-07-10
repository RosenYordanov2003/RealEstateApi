namespace RealEstate.Core.Commands.Pictures
{
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public record CreatePictureCommand(string path, IFormFile file, Guid propertyId) : IRequest;
}
