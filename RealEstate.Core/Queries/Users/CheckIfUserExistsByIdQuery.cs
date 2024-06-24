namespace RealEstate.Core.Queries.Users
{
    using MediatR;
    public record CheckIfUserExistsByIdQuery(Guid userId) : IRequest<bool>;
  
}
