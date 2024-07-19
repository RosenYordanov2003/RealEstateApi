namespace RealEstate.Core.Queries.Users
{
    using MediatR;
    public record GetUserEmailsQuery(int categoryId) : IRequest<IEnumerable<string>>;

}
