namespace RealEstate.Core.Models.Property
{
    using Microsoft.AspNetCore.Http;

    public class CreatePropertyModel : EditPropertyModel
    {
        public IFormFileCollection Files { get; set; } = null!;
    }
}
