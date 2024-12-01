using System.Security.Claims;

namespace ServiceRequests.Common.Services;

public interface ITokenService
{
    string GenerateToken(string userId, string userName, string role);
    string GetUserName(ClaimsPrincipal user);
}