using System.IO.Compression;
using LearningManagement.Occupation.Application;
using LearningManagement.Aquamation.Infrastructure;
using LearningManagement.Occupation.Domain;

namespace LearningManagement.Occupation.WebAPI;

public static class ServiceRegistrations {
    public static void AddServices(IServiceCollection service, string sqlConnectionString) {
        DomainServiceRegistration.AddServices(service);
        ApplicationServiceRegistration.AddServices(service);
        InfrastructureServiceRegistration.AddServices(service, sqlConnectionString);
        AddWebApiServices(service);
    }

    public static void AddWebApiServices(IServiceCollection services) {
        #region Grpc Client Config

        services.AddGrpc(options => {
            options.ResponseCompressionLevel = CompressionLevel.Optimal;
            options.ResponseCompressionAlgorithm = "gzip";
            options.MaxSendMessageSize = 1024 * 1024 * 1024; // 1 GB
            options.MaxReceiveMessageSize = 1024 * 1024 * 1024; // 1 GB
        });

        #endregion
    }
}