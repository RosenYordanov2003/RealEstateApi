namespace RealEstate.Core.Queries.PropertyCategories
{
    using MediatR;
    using Core.Models.PropertyCategories;

    public record GetPropertyCategoriesQuery : IRequest<IEnumerable<PropertyCategoryModel>>;
    
}
