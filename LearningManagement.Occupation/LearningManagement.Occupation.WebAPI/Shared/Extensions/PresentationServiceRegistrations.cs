namespace LearningManagement.Occupation.WebAPI.Shared.Extensions;

public static class PresentationServiceRegistrations {
    public static void AddPresentation(this IServiceCollection services, IConfiguration configuration) {
        services.ConfigureCrossOriginPolicy(configuration);
        services.AddSwaggerServices();
    }

    public static void UsePresentation(this WebApplication app) {
        app.AllowSpecificOrigins();
        app.UseSwaggerAndUi();
    }
}