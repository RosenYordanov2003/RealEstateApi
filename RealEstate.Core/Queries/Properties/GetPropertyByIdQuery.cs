
namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    using Models.Property;

    public record GetPropertyByIdQuery(Guid id) : IRequest<PropertyDetailsModel>;
   
}
