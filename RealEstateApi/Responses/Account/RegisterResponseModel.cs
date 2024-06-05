namespace RealEstate.Responses.Account
{
    public class RegisterResponseModel
    {
        public RegisterResponseModel(bool success, params string[] errors)
        {
            Errors = new List<string>();
            Success = success;
            if (errors != null && errors.Length > 0)
            {
                Errors = errors;
            }
        }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
