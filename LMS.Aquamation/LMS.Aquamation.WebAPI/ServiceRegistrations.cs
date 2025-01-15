using System.IO.Compression;
using LMS.Aquamation.Application;
using LMS.Aquamation.Core;
using LMS.Aquamation.Infrastructure;

namespace LMS.Aquamation.WebAPI;

public static class ServiceRegistrations {
    public static void AddServices(IServiceCollection service, string sqlConnectionString) {
        ApplicationServiceRegistration.AddServices(service);
        InfrastructureServiceRegistration.AddServices(service, sqlConnectionString);
        DomainServiceRegistration.AddServices(service);
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