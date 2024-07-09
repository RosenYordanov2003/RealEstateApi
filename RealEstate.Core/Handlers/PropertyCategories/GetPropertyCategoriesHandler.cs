namespace RealEstate.Core.Handlers.PropertyCategories
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Models.PropertyCategories;
    using Queries.PropertyCategories;
    using Data.Data.Models;
    using Data.Repositories.Contracts;

    public class GetPropertyCategoriesHandler : IRequestHandler<GetPropertyCategoriesQuery, IEnumerable<PropertyCategoryModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPropertyCategoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PropertyCategoryModel>> Handle(GetPropertyCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<PropertyCategory>()
                .GetAll(false)
                .Select(pc => new PropertyCategoryModel()
                {
                    Id = pc.Id,
                    Name = pc.Name
                })
                .ToArrayAsync();
        }
    }
}
