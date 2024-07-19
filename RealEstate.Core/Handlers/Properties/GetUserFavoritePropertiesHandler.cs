namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Models.Property;
    using Queries.Properties;
    using Data.Repositories.Contracts;
    using RealEstate.Data.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class GetUserFavoritePropertiesHandler : IRequestHandler<GetUserFavoritePropertiesQuery, IEnumerable<PropertyModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserFavoritePropertiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PropertyModel>> Handle(GetUserFavoritePropertiesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<UserFavoriteProperties>()
                .GetAll(false, ufp => ufp.UserId == request.userId)
                .Select(ufp => new PropertyModel()
                {
                    Id = ufp.PropertyId,
                    City = ufp.Property.City.Name,
                    Address = ufp.Property.Address,
                    ImgUrl = ufp.Property.Pictures.Select(x => x.ImgUrl).FirstOrDefault(),
                    Name = ufp.Property.Name,
                    Price = ufp.Property.Price,
                    SquareMeters = ufp.Property.SquareMeters,
                    Category = ufp.Property.PropertyCategory.Name,
                    CategoryId = ufp.Property.PropertyCategory.Id,
                })
                .ToArrayAsync();
        }
    }
}
