namespace RealEstate.Core.Contracts
{
    using Models.Property;
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyModel>> GetAllPropertiesByCategoryAsync(string propertyCategory, 
            string saleCategory);
    }
}
