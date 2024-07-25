namespace RealEstate.Responses.Pictures
{
    using Core.Models.Pictures;
    public class PictureResponseModel : BaseResponseModel
    {
        public PictureResponseModel(string message, bool success, PictureModel model) : base(message, success)
        {
            Model = model;
        }
        public PictureModel Model { get; private set; }
    }
}
