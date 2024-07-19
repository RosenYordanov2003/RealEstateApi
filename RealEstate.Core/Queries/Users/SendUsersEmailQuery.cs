namespace RealEstate.Core.Queries.Users
{
    using MediatR;
    public record SendUsersEmailQuery(IEnumerable<string> emails) : IRequest;

}
