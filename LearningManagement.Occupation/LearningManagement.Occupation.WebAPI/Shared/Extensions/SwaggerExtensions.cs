namespace LearningManagement.Occupation.WebAPI.Shared.Extensions;

public static class SwaggerExtensions {
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services) {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => {
            //options.CustomSchemaIds(type => type.FullName);
            options.CustomSchemaIds(type => $"{type.Name}_{Guid.NewGuid()}");
        });

        return services;
    }

    public static IApplicationBuilder UseSwagger(
        this IApplicationBuilder builder, WebApplication app) {
        if (app.Environment.IsProduction())
            return app;
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}