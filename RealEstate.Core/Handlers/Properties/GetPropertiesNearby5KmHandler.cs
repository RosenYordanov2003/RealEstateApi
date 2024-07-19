namespace RealEstate.Core.Handlers.Properties
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using NetTopologySuite;
    using Models.Property;
    using Queries.Properties;
    using Data.Repositories.Contracts;
    using static GlobalConstants.ApplicationConstants;
    using NetTopologySuite.Geometries;
    using Data.Data.Models;

    public class GetPropertiesNearby5KmHandler : IRequestHandler<GetPropertiesNearby5KmQuery, IEnumerable<PropertyModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private const double DISTANCE_IN_METERS = 5000;
        public GetPropertiesNearby5KmHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PropertyModel>> Handle(GetPropertiesNearby5KmQuery request, CancellationToken cancellationToken)
        {
            GeometryFactory factory = NtsGeometryServices.Instance.CreateGeometryFactory(DEFAULT_SRID);

            Point currentLocation = factory.CreatePoint(new Coordinate(request.longitude, request.latitude));

            return await _unitOfWork
                .Repository<Property>()
                .GetAll(false, x => x.Location.IsWithinDistance(currentLocation, DISTANCE_IN_METERS))
                .Select(p => new PropertyModel()
                {
                    Address = p.Address,
                    City = p.City.Name,
                    BathRoomsCount = p.BathRoomsCount,
                    BedRoomsCount = p.BedRoomsCount,
                    Id = p.Id,
                    ImgUrl = p.Pictures == null ? null : p.Pictures.First().ImgUrl,
                    Name = p.Name,
                    Price = p.Price,
                    SquareMeters = p.SquareMeters,
                    Category = p.PropertyCategory.Name,
                    CategoryId = p.PropertyCategory.Id
                })
                .ToArrayAsync();
        }
    }
}
