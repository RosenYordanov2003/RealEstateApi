namespace RealEstate.Core.Commands.Pictures
{
    using MediatR;

    public record DeletePictureCommand(string webRoothPath, int imgId, string imgFileName) : IRequest;
}
