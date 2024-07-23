namespace RealEstate.Responses.Account
{
    using Core.Models.Account;
    public class ResetPasswordResponseModel : BaseResponseModel
    {
        public ResetPasswordResponseModel(ResetPasswordModel model, string message, bool success) : base(message, success)
        {
            Model = model;
        }

        public ResetPasswordModel Model { get; private set; }
    }
}
