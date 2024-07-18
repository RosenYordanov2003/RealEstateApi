namespace RealEstate.Data.Repositories
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using NetTopologySuite.Geometries;
    using NetTopologySuite;
    using NetTopologySuite.Geometries.Utilities;
    using Data.Models;
    using Core.Models.Property;
    using Data;
    using Contracts;
    using Core.Models.Pictures;
    using Core.Models.Amenities;
    using static GlobalConstants.ApplicationConstants;
    using ProjNet.CoordinateSystems.Transformations;
    using ProjNet.CoordinateSystems;

    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        private readonly ApplicationDbContext _context;
        private const double DISTANCE_IN_METERS = 1000;
        public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<PropertyDetailsModel> GetPropertyById(Guid id)
        {
            GeometryFactory factory = NtsGeometryServices.Instance.CreateGeometryFactory(DEFAULT_SRID);

            PropertyDetailsModel model = await _context
                   .Properties
                   .Select(p => new PropertyDetailsModel()
                   {
                       Id = p.Id,
                       Address = p.Address,
                       BathRoomsCount = p.BathRoomsCount,
                       BedRoomsCount = p.BedRoomsCount,
                       City = p.City.Name,
                       Description = p.Description,
                       Latitude = p.Location.Y,
                       Longitude = p.Location.X,
                       Name = p.Name,
                       Price = p.Price,
                       SquareMeters = p.SquareMeters,
                       Pictures = p.Pictures.Select(p => new PictureModel() { Id = p.Id, ImgUrl = p.ImgUrl }).ToArray(),
                       Amenities = _context.Amenities
                        .Where(a => a.Location.IsWithinDistance(p.Location, DISTANCE_IN_METERS))
                        .Select(a => new AmenityModel()
                        {
                            Name = a.Name,
                            CategoryName = a.AmenityCategory.Name,
                            Longitude = a.Location.Y,
                            Latitude = a.Location.X,
                            Distance = Math.Round(CalculateDistanceInMeters(p.Location, a.Location), 2)
                        })
                        .ToList()
                   })
                   .FirstAsync(p => p.Id == id);

            return model;
        }

        //Static due to EF Exception
        private static double CalculateDistanceInMeters(Point location1, Point location2)
        {
            var wgs84 = GeographicCoordinateSystem.WGS84;

            var factory = new CoordinateTransformationFactory();
            var wgs84ToUtm = factory.CreateFromCoordinateSystems(wgs84, ProjectedCoordinateSystem.WGS84_UTM(33, true));

           
            var utm1 = wgs84ToUtm.MathTransform.Transform(new[] { location1.X, location1.Y });
            var utm2 = wgs84ToUtm.MathTransform.Transform(new[] { location2.X, location2.Y });

            var distance = Math.Sqrt(Math.Pow(utm1[0] - utm2[0], 2) + Math.Pow(utm1[1] - utm2[1], 2));

            return distance;
        }

    }
}
