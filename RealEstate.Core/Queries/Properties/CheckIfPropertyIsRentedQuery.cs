namespace RealEstate.Core.Queries.Properties
{
    using MediatR;
    using Models.Property;
    public record CheckIfPropertyIsRentedQuery(BookPropertyModel model) : IRequest<bool>;
}
