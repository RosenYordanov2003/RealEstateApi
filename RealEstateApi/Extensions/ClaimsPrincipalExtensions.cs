namespace RealEstate.Extensions
{
    using System.Security.Claims;
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            string? username = (user.FindFirstValue(ClaimTypes.NameIdentifier));

            return username != null ? username : "";

        }
    }
}
