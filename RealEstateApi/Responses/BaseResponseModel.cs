namespace RealEstate.Responses
{
    public class BaseResponseModel
    {
        public BaseResponseModel(string message, bool success)
        {
            Message = message; 
            Success = success;
        }
        public string Message { get; set; } = null!;
        public bool Success { get; set; }
    }
}
