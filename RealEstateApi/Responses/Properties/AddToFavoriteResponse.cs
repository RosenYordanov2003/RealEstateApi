﻿namespace RealEstate.Responses.Properties
{
    public class AddToFavoriteResponse
    {
        public AddToFavoriteResponse(bool success, string? errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
