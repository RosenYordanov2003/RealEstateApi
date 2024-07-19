namespace RealEstate.Core.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using Data.Data.Models;
    using static GlobalConstants.ApplicationConstants;
    using RealEstate.Core.Contracts.Account;

    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        public AccountService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> GenerateJwtTokenAsync(User user, SymmetricSecurityKey securityKey, string issuer, string audience)
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(await GetUserClaims(user)),
                Expires = DateTime.UtcNow.AddMinutes(JWT_TOKEN_EXPIRATION_TIME),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
            };
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        private async Task<IEnumerable<Claim>> GetUserClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            claims.AddRange(userClaims);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return claims;
        }
    }
}
