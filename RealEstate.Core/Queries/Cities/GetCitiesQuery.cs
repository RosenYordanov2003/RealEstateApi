namespace RealEstate.Core.Queries.Cities
{
    using MediatR;
    using Models.Cities;

    public record GetCitiesQuery : IRequest<IEnumerable<CityModel>>;
    
}
