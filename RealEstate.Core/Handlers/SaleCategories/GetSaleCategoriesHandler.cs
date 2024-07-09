namespace RealEstate.Core.Handlers.SaleCategories
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Models.SaleCategories;
    using Queries.SaleCategories;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class GetSaleCategoriesHandler : IRequestHandler<GetSaleCategoriesQuery, IEnumerable<SalesCategoryModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetSaleCategoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SalesCategoryModel>> Handle(GetSaleCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork
                .Repository<SaleCategory>()
                .GetAll(false)
                .Select(sc => new SalesCategoryModel()
                {
                    Id = sc.Id,
                    Name = sc.Name
                })
                .ToArrayAsync();
        }
    }
}
