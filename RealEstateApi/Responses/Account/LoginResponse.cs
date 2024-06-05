namespace RealEstate.Responses.Account
{
    public class LoginResponseModel : RegisterResponseModel
    {
        public LoginResponseModel(bool success, string? jwtToken, params string[] errors) : base(success, errors)
        {
            JwtToken = jwtToken;
        }
        public string? JwtToken { get; set; }
    }
}
