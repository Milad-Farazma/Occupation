namespace LearningManagement.Occupation.WebAPI.Shared.Extensions;

public static class CorsExtensions {
    public static IServiceCollection ConfigureCrossOriginPolicy(
        this IServiceCollection services, IConfiguration configuration) {
        var allowedOrigins = configuration.GetSection("AllowedCorsOrigins").Get<string[]>() ?? [];

        services.AddCors(options => options
            .AddPolicy("AllowSpecificOrigins", builder => builder
                .WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()));

        return services;
    }

    public static IApplicationBuilder AllowSpecificOrigins(this WebApplication app) {
        app.UseCors("AllowSpecificOrigins");
        return app;
    }
}