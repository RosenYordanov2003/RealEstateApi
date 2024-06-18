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

    public class GetTopTenPropertiesHandler : IRequestHandler<GetTopTenPropertiesQuery, IEnumerable<PropertyModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetTopTenPropertiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PropertyModel>> Handle(GetTopTenPropertiesQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.Repository<Property>().GetAll(false, p => p.PropertyCategory.Name.ToLower() == request.propertyCategory.ToLower()
            && p.SaleCategory.Name.ToLower() == request.salesCateogry.ToLower());

            return await result.Select(p => new PropertyModel()
            {
                Id = p.Id,
                SquareMeters = p.SquareMeters,
                Address = p.Address,
                City = p.City.Name,
                ImgUrl = null,
                Name = p.Name,
                Price = p.Price
            })
           .Take(10)
           .ToArrayAsync();
        }
    }
}
