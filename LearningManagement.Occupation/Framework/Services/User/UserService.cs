using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Framework.Services.User;

public sealed class UserService(
    IHttpContextAccessor httpContextAccessor,
    ILogger<UserService> logger) : IUserService {
    public long GetCurrentUserId() {
        var user = httpContextAccessor.HttpContext?.User;

        var isAuthenticated = user?.Identity?.IsAuthenticated;

        if (!isAuthenticated ?? false) {
            logger.LogWarning("Trying to get current userId for an unauthenticated user!, " +
                              "HttpContextRequest: {Request}", httpContextAccessor.HttpContext?.Request);
            return 0;
        }

        var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(userIdClaim) || !long.TryParse(userIdClaim, out var userId)) {
            logger.LogWarning("Trying to get current userId for an user without userId claim!, " +
                              "HttpContextRequest: {Request}", httpContextAccessor.HttpContext?.Request);
            return 0;
        }

        return userId;
    }
}