namespace RealEstate.Core.Queries.Pictures
{
    using MediatR;
    using Models.Pictures;
    public record GetPictureByIdQuery(int id) : IRequest<PictureModel>;
}
