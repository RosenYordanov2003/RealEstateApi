namespace RealEstate.Core.Handlers.Properties
{
    using System.Threading.Tasks;
    using System.Threading;
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Queries.Properties;
    using Models.Property;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class GetUserPropertiesHandler : IRequestHandler<GetUserPropertiesQuery, IEnumerable<PropertyModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserPropertiesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PropertyModel>> Handle(GetUserPropertiesQuery request, CancellationToken cancellationToken)
        {
            return await
               _unitOfWork.Repository<Property>()
              .GetAll(false,
               p => p.OwnerId == request.userId)
              .Select(p => new PropertyModel()
              {
                  Address = p.Address,
                  City = p.City.Name,
                  Price = p.Price,
                  Id = p.Id,
                  ImgUrl = p.Pictures.Select(p => p.ImgUrl).FirstOrDefault(),
                  Name = p.Name,
                  SquareMeters = p.SquareMeters
              })
              .ToArrayAsync();
        }


        // return await
        //        _unitOfWork.Repository<Property>()
        //       .GetAll(false,
        //        p => p.OwnerId == request.userId, p => p.OrderByDescending(x => x.SquareMeters))
        //       .Select(p => new PropertyModel()
        //{
        //    Address = p.Address,
        //           City = p.City.Name,
        //           Price = p.Price,
        //           Id = p.Id,
        //           ImgUrl = p.Pictures.Select(p => p.ImgUrl).FirstOrDefault(),
        //           Name = p.Name,
        //           SquareMeters = p.SquareMeters
        //       })
        //       .ToArrayAsync();
    }
}
