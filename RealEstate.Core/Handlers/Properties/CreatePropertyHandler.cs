namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Commands.Properties;
    using Data.Repositories.Contracts;
    using Models.Property;
    using Data.Data.Models;
    using NetTopologySuite.Geometries;
    using static GlobalConstants.ApplicationConstants;

    public class CreatePropertyHandler : IRequestHandler<CreatePropertyCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePropertyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            CreatePropertyModel model = request.model;

            Property propertyToCreate = new Property()
            {
                Name = model.Name,
                CityId = model.CityId,
                BathRoomsCount = model.BathRoomsCount,
                BedRoomsCount = model.BedRoomsCount,
                PropertyCategoryId = model.PropertyCategoryId,
                SaleCategoryId = model.SaleCategoryId,
                Address = model.Address,
                Description = model.Description,
                FloorNumber = model.FloorNumber,
                Location = new Point(model.Longitude, model.Latitude) { SRID = DEFAULT_SRID },
                IsDeleted = false,
                Price = model.Price,
                SquareMeters = model.SquareMeters,
                OwnerId = request.ownerId
            };

            await _unitOfWork.Repository<Property>().AddAsync(propertyToCreate);
            await _unitOfWork.SaveChangesAsync();

            return propertyToCreate.Id;
        }
    }
}
