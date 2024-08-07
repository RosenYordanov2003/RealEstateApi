﻿namespace RealEstate.Core.Contracts.Account
{
    using Microsoft.IdentityModel.Tokens;
    using Data.Data.Models;

    public interface IAccountService
    {
        Task<string> GenerateJwtTokenAsync(User user, SymmetricSecurityKey securityKey, string issuer, string audience);
    }
}
