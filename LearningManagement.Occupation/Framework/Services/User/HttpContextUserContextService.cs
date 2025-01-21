using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Framework.Services.User;

public sealed class HttpContextUserContextService(IHttpContextAccessor httpContextAccessor) : IUserContextService {
    public long GetCurrentUserId() {
        var user = httpContextAccessor.HttpContext?.User;

        var isAuthenticated = user?.Identity?.IsAuthenticated;

        if (!isAuthenticated ?? false) {
            return 0;
        }

        var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(userIdClaim) || !long.TryParse(userIdClaim, out var userId)) {
            return 0;
        }

        return userId;
    }
}