namespace RealEstate.Core.Services
{
    using Contracts;
    using Models.Property;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PropertyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PropertyModel>> GetAllPropertiesByCategoryAsync(string propertyCategory, string saleCategory)
        {
            var result = await _unitOfWork.Repository<Property>().GetAllAsync(false, p => p.PropertyCategory.Name.ToLower() == propertyCategory.ToLower()
            && p.SaleCategory.Name.ToLower() == saleCategory.ToLower(), null, p => p.City);

            return result.Select(p => new PropertyModel()
            {
                Id = p.Id,
                SquareMeters = p.SquareMeters,
                Address = p.Address,
                City = p.City.Name,
                ImgUrl = null,
                Name = p.Name,
                Price = p.Price
            })
             .Take(10);
        }
    }
}
