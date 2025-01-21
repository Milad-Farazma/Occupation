using Microsoft.Extensions.Logging;

namespace Framework.Services.User;

public sealed class UserService(
    IUserContextService userContextService,
    ILogger<UserService> logger) : IUserService {
    public long GetCurrentUserId() {
        var userId = userContextService.GetCurrentUserId();
        if (userId == 0) {
            logger.LogWarning("Trying to get current userId for an unauthenticated user or user without userId claim.");
        }

        return userId;
    }
}