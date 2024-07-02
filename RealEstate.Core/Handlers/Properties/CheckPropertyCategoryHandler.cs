namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Core.Queries.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class CheckPropertyCategoryHandler : IRequestHandler<CheckPropertyCategoryQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CheckPropertyCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckPropertyCategoryQuery request, CancellationToken cancellationToken)
        {
            Property property = await _unitOfWork.Repository<Property>().GetByAsync(p => p.Id == request.propertyId)
                 .FirstAsync();

            bool result = property.SaleCategoryId == 3 ? false : true;

            return result;
        }
    }
}
