namespace RealEstate.Core.Queries.Pictures
{
    using MediatR;
    public record CheckIfPictureExistsByIdQuery(int id) : IRequest<bool>;
}
