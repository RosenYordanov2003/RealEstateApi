namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    public record CheckIfPropertyExistsQuery(Guid id) : IRequest<bool>;

}
