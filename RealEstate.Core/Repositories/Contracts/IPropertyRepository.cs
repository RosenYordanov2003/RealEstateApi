namespace RealEstate.Data.Repositories.Contracts
{
    using Core.Models.Property;

    public interface IPropertyRepository
    {
        Task<PropertyDetailsModel> GetPropertyById(Guid id);
    }
}
