namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    using Models.Property;

    public record GetFilteredPropertiesQuery(FilterPropertyModel filter) : IRequest<IEnumerable<PropertyModel>>;
}
