namespace RealEstate.Core.Handlers.Cities
{
    using MediatR;
    using Models.Cities;
    using Queries.Cities;
    using Data.Repositories.Contracts;
    using RealEstate.Data.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, IEnumerable<CityModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCitiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CityModel>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<City>()
                .GetAll(false)
                .Select(c => new CityModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();
        }
    }
}
