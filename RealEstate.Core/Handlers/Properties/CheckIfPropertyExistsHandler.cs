namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Queries.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class CheckIfPropertyExistsHandler : IRequestHandler<CheckIfPropertyExistsQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CheckIfPropertyExistsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfPropertyExistsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Property>().CheckIfExistsByIdAsync(x => x.Id == request.id);
        }
    }
}
