namespace RealEstate.Core.Handlers.Amenities
{
    using System.Globalization;
    using MediatR;
    using NetTopologySuite.Geometries;
    using CsvHelper;
    using Commands.Amenities;
    using Data.Repositories.Contracts;
    using Data.Data.Models;
    using Models.Amenities;
    using CsvHelper.Configuration;
    using static GlobalConstants.ApplicationConstants;

    public class InsertAmenitiesHandler : IRequestHandler<InsertAmenitiesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public InsertAmenitiesHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task Handle(InsertAmenitiesCommand request, CancellationToken cancellationToken)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null, 
                BadDataFound = null
            };
            using (StreamReader reader = new StreamReader(request.filePath))
            using (CsvReader csv = new CsvReader(reader, csvConfig))
            {
                var records = csv.GetRecords<InsertAmenityModel>().ToList();

                foreach (var record in records)
                {
                    Amenity amenity = new Amenity
                    {
                        Name = record.Name,
                        Location = new Point(record.Longitude, record.Latitude) { SRID = DEFAULT_SRID},
                        AmenityCategoryId = request.amenityCateogryId,
                    };
                    await _unitOfWork.Repository<Amenity>().AddAsync(amenity);
                }

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
