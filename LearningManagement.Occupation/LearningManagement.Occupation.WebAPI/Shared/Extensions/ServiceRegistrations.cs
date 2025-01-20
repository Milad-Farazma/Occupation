namespace LearningManagement.Occupation.WebAPI.Shared.Extensions;

public static class ServiceRegistrations {
    public static void AddPresentationServices(this IServiceCollection services, string[] origins) {
        services.AddAppCors(origins);
    }

    private static void AddAppCors(this IServiceCollection services, string[] origins) {
        // Add CORS services
        services.AddCors(options => {
            options.AddPolicy("AllowSpecificOrigins", builder => {
                builder.WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}