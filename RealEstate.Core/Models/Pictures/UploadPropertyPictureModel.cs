namespace RealEstate.Core.Models.Pictures
{
    using Microsoft.AspNetCore.Http;
    public class UploadPropertyPictureModel
    {
        public IFormFile File { get; set; } = null!;
        public Guid PropertyId { get; set; }
    }
}
