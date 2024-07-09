namespace RealEstate.Core.Handlers.Properties
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Models.Property;
    using Data.Data.Models;
    using Data.Repositories.Contracts;
    using Queries.Properties;

    public class GetFilteredPropertiesHandler : IRequestHandler<GetFilteredPropertiesQuery, IEnumerable<PropertyModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetFilteredPropertiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PropertyModel>> Handle(GetFilteredPropertiesQuery request, CancellationToken cancellationToken)
        {
            var properties =  _unitOfWork.Repository<Property>().GetAll(false);

            FilterPropertyModel filterModel = request.filter;

            if (filterModel.MaxPrice.HasValue)
            {
                properties = properties.Where(p => p.Price <= filterModel.MaxPrice);
            }
            if (filterModel.MinSquareMeters.HasValue)
            {
                properties = properties.Where(p => p.SquareMeters >= filterModel.MinSquareMeters);
            }
            if (filterModel.MaxSquareMeters.HasValue)
            {
                properties = properties.Where(p => p.SquareMeters <= filterModel.MaxSquareMeters);
            }
            if (filterModel.MaxPrice.HasValue)
            {
                properties = properties.Where(p => p.Price <= filterModel.MaxPrice);
            }
            if (filterModel.SaleCategoryId.HasValue)
            {
                properties = properties.Where(p => p.SaleCategoryId == filterModel.SaleCategoryId);
            }
            if (filterModel.PropertyCategoryId.HasValue)
            {
                properties = properties.Where(p => p.PropertyCategoryId == filterModel.PropertyCategoryId);
            }
            if (filterModel.CityId.HasValue)
            {
                properties = properties.Where(p => p.CityId == filterModel.CityId);
            }
            if (filterModel.BathRoomsCount.HasValue)
            {
                properties = properties.Where(p => p.BathRoomsCount == filterModel.BathRoomsCount);
            }
            if (filterModel.BedRoomsCount.HasValue)
            {
                properties = properties.Where(p => p.BedRoomsCount == filterModel.BedRoomsCount);
            }

            return await properties
                .Select(p => new PropertyModel()
                {
                    Id = p.Id,
                    SquareMeters = p.SquareMeters,
                    Address = p.Address,
                    City = p.City.Name,
                    ImgUrl = null,
                    Name = p.Name,
                    Price = p.Price,
                    BathRoomsCount = p.BathRoomsCount,
                    BedRoomsCount = p.BedRoomsCount
                })
                .ToArrayAsync();
        }
    }
}
