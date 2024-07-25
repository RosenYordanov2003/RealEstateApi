namespace RealEstate.Core.Handlers.Pictures
{
    using MediatR;
    using Core.Queries.Pictures;
    using Data.Data.Models;
    using Data.Repositories.Contracts;
    public class CheckIfPictureExistsByIdHandler : IRequestHandler<CheckIfPictureExistsByIdQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CheckIfPictureExistsByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CheckIfPictureExistsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Picture>().CheckIfExistsByIdAsync(p => p.Id == request.id);
        }
    }
}
