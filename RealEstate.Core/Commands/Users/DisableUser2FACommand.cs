namespace RealEstate.Core.Commands.Users
{
    using MediatR;
    public record DisableUser2FACommand(string userName) : IRequest;

}
