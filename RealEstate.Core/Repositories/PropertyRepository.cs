namespace RealEstate.Data.Repositories
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using NetTopologySuite.Geometries;
    using NetTopologySuite;
    using Data.Models;
    using Core.Models.Property;
    using Data;
    using Contracts;
    using Core.Models.Pictures;
    using static GlobalConstants.ApplicationConstants;
    using Core.Models.Amenities;

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
                            Latitude = a.Location.X
                        })
                        .ToList()

                   })
                   .FirstAsync(p => p.Id == id);

            return model;
        }
    }
}
