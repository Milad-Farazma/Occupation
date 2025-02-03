using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Framework.Services.User;

public sealed class HttpContextUserContextService(IHttpContextAccessor httpContextAccessor) : IUserContextService {
    public Guid GetCurrentUserId() {
        var user = httpContextAccessor.HttpContext?.User;

        var isAuthenticated = user?.Identity?.IsAuthenticated;

        if (!isAuthenticated ?? false) {
            return Guid.NewGuid();
        }

        var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId)) {
            return Guid.Empty;
        }

        return userId;
    }
}