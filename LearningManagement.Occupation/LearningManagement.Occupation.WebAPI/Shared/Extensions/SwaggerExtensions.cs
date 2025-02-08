namespace LearningManagement.Occupation.WebAPI.Shared.Extensions;

public static class SwaggerExtensions {
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services) {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSwaggerGen(c => {
            c.CustomSchemaIds(type => type.FullName); // Use full namespace to avoid conflicts
        });


        return services;
    }

    public static IApplicationBuilder UseSwaggerAndUi(this WebApplication app) {
        // if (app.Environment.IsProduction())
        //     return app;

        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}