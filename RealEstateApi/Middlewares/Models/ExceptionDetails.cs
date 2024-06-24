namespace RealEstate.Middlewares.Models
{
    public class ExceptionDetails
    {
        public ExceptionDetails(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; } = null!;
    }
}
