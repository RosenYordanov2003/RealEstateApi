namespace RealEstate.Responses.Properties
{
    public class PropertyBaseResponseModel
    {
        public PropertyBaseResponseModel(bool success, string? errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
