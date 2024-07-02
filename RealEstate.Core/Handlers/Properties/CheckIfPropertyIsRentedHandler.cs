namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Queries.Properties;
    using Data.Data.Models;
    using Data.Repositories.Contracts;

    public class CheckIfPropertyIsRentedHandler : IRequestHandler<CheckIfPropertyIsRentedQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CheckIfPropertyIsRentedHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CheckIfPropertyIsRentedQuery request, CancellationToken cancellationToken)
        {
            var model = request.model;
            var result = await _unitOfWork.Repository<PropertiesRents>()
                .GetByAsync(pr => pr.PropertyId == request.model.Id
                      &&
                     ((pr.StartDate <= model.EndDate && pr.EndDate >= model.EndDate) ||
                     (pr.StartDate >= model.StartDate && pr.EndDate <= model.EndDate)))
                .FirstOrDefaultAsync();

            bool iSAvailableForRent = result == null ? true : false;

            return iSAvailableForRent;
        }
    }
}
