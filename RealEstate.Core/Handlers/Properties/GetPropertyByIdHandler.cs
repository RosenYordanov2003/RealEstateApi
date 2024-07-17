namespace RealEstate.Core.Handlers.Properties
{
    using Microsoft.EntityFrameworkCore;
    using NetTopologySuite.Geometries;
    using NetTopologySuite;
    using MediatR;
    using Models.Property;
    using Queries.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;
    using Models.Pictures;
    using static GlobalConstants.ApplicationConstants;
    using RealEstate.Core.Models.Amenities;

    public class GetPropertyByIdHandler : IRequestHandler<GetPropertyByIdQuery, PropertyDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private const double DISTANCE_IN_METERS = 1000;

        public GetPropertyByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<PropertyDetailsModel> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            PropertyDetailsModel model = await _unitOfWork.Repository<Property>().GetByAsync(x => x.Id == request.id)
                .Select(x => new PropertyDetailsModel()
                {
                    Id = x.Id,
                    Address = x.Address,
                    BathRoomsCount = x.BathRoomsCount,
                    BedRoomsCount = x.BedRoomsCount,
                    City = x.City.Name,
                    Description = x.Description,
                    Latitude = x.Location.Y,
                    Longitude = x.Location.X,
                    Name = x.Name,
                    Price = x.Price,
                    SquareMeters = x.SquareMeters,
                    Pictures = x.Pictures.Select(p => new PictureModel() { Id = p.Id, ImgUrl = p.ImgUrl }).ToArray(),
                })
                .FirstAsync();

            GeometryFactory factory = NtsGeometryServices.Instance.CreateGeometryFactory(DEFAULT_SRID);

            Point currentLocation = factory.CreatePoint(new Coordinate(model.Longitude, model.Latitude));

            model.Amenities = await _unitOfWork.Repository<Amenity>()
                .GetAll(false, a => a.Location.IsWithinDistance(currentLocation , DISTANCE_IN_METERS))
                .Select(a => new AmenityModel()
                {
                    Name = a.Name,
                    CategoryName = a.AmenityCategory.Name,
                    Longitude = a.Location.Y,
                    Latitude = a.Location.X
                })
                .ToArrayAsync();

            return model;
        }
    }
}
