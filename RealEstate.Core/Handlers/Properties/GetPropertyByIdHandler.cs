namespace RealEstate.Core.Handlers.Properties
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Models.Property;
    using Queries.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;
    using Models.Pictures;

    public class GetPropertyByIdHandler : IRequestHandler<GetPropertyByIdQuery, PropertyDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPropertyByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<PropertyDetailsModel> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Property>().GetByIdAsync(x => x.Id == request.id)
                .Select(x => new PropertyDetailsModel()
                {
                    Id = x.Id,
                    Address = x.Address,
                    BathRoomsCount = x.BathRoomsCount,
                    BedRoomsCount = x.BedRoomsCount,
                    City = x.City.Name,
                    Description = x.Description,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Name = x.Name,
                    Price = x.Price,
                    SquareMeters = x.SquareMeters,
                    Pictures = x.Pictures.Select(p => new PictureModel() { Id = p.Id, ImgUrl = p.ImgUrl }).ToArray()
                })
                .FirstAsync();
        }
    }
}
