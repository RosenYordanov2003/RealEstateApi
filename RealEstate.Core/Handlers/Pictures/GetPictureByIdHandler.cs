namespace RealEstate.Core.Handlers.Pictures
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Core.Models.Pictures;
    using Core.Queries.Pictures;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class GetPictureByIdHandler : IRequestHandler<GetPictureByIdQuery, PictureModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPictureByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PictureModel> Handle(GetPictureByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Picture>()
                .GetByAsync(p => p.Id == request.id)
                .Select(p => new PictureModel()
                {
                    Id = p.Id,
                    ImgUrl = p.ImgUrl,
                })
                .FirstAsync();
        }
    }
}
