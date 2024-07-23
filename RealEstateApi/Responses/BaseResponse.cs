namespace RealEstate.Responses
{
    public class BaseResponse
    {
        public BaseResponse(string message, bool success)
        {
            Message = message; 
            Success = success;
        }
        public string Message { get; set; } = null!;
        public bool Success { get; set; }
    }
}
