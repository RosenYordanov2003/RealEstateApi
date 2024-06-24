namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Commands;
    using Data.Repositories.Contracts;
    using RealEstate.Data.Data.Models;

    public class AddPropertyToUserFavoriteHandler : IRequestHandler<AddPropertyToUserFavoriteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddPropertyToUserFavoriteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddPropertyToUserFavoriteCommand request, CancellationToken cancellationToken)
        {
            UserFavoriteProperties userFavoriteProperties = new UserFavoriteProperties()
            {
                PropertyId = request.model.PropertyId,
                UserId = request.model.UserId
            };
            await _unitOfWork.Repository<UserFavoriteProperties>().AddAsync(userFavoriteProperties);
        }
    }
}
