namespace RealEstate.Core.Handlers.Properties
{
    using Microsoft.EntityFrameworkCore;
    using NetTopologySuite.Geometries;
    using NetTopologySuite;
    using MediatR;
    using Models.Property;
    using Queries.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;
    using Models.Pictures;
    using static GlobalConstants.ApplicationConstants;
    using RealEstate.Core.Models.Amenities;

    public class GetPropertyByIdHandler : IRequestHandler<GetPropertyByIdQuery, PropertyDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private const double DISTANCE_IN_METERS = 1000;

        public GetPropertyByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<PropertyDetailsModel> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.PropertyRepository.GetPropertyById(request.id);

            return model;
           
        }
    }
}
