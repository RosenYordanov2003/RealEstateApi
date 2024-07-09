namespace RealEstate.Core.Queries.Users
{
    using MediatR;
    public record GetUserIdQuery (string userName) : IRequest<Guid>;
}
