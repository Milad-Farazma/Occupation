namespace LearningManagement.Occupation.WebAPI.Shared.Extensions;

public static class ServiceRegistrations {
    public static void AddPresentation(this IServiceCollection services, IConfiguration configuration) {
        services.ConfigureCrossOriginPolicy(configuration);
        services.AddSwaggerServices();
    }
}