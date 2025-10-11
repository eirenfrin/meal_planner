using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null || !Guid.TryParse(userId, out Guid id))
        {
            throw new UnauthorizedAccessException("User ID could not be extracted from claims");
        }

        return id;
    }
}