namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    using Models.Property;

    public record GetUserPropertiesQuery(Guid userId) : IRequest<IEnumerable<PropertyModel>>;
   
}
