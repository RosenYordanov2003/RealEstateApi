namespace RealEstate.Core.Commands.Pictures
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Core.Models.Pictures;

    public record CreatePictureCommand(string path, IFormFile file, Guid propertyId) : IRequest<PictureModel>;
}
