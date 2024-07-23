
namespace RealEstate.Core.Commands.Users
{
    using MediatR;
    public record EnableUser2FACommand(string userName) : IRequest;

}
