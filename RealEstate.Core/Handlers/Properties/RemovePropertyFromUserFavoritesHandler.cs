namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Core.Commands;
    using Data.Data.Models;
    using Data.Repositories.Contracts;

    public class RemovePropertyFromUserFavoritesHandler : IRequestHandler<RemoveProeprtyFromUserFavoriteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemovePropertyFromUserFavoritesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(RemoveProeprtyFromUserFavoriteCommand request, CancellationToken cancellationToken)
        {
            UserFavoriteProperties userFavoriteProperties = await _unitOfWork.Repository<UserFavoriteProperties>()
                .GetByAsync(ufp => ufp.UserId == request.model.UserId && ufp.PropertyId == request.model.PropertyId)
                .FirstOrDefaultAsync();

            if (userFavoriteProperties == null)
            {
                throw new InvalidOperationException();
            }
            await _unitOfWork.Repository<UserFavoriteProperties>().DeleteAsync(userFavoriteProperties);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
