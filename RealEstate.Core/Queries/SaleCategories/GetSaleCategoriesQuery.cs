namespace RealEstate.Core.Queries.SaleCategories
{
    using MediatR;
    using Models.SaleCategories;
    public record GetSaleCategoriesQuery : IRequest<IEnumerable<SalesCategoryModel>>;
}
