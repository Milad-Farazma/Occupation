using System.IO.Compression;
using Framework.Services.User;
using LearningManagement.Occupation.Application.Companies.Contracts;
using LearningManagement.Occupation.Application.Companies.Services;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Services;
using LearningManagement.Occupation.Application.SampleGrpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LearningManagement.Occupation.Application.Shared;

public static class ApplicationServiceRegistration {
    public static void AddServices(IServiceCollection service) {
        service.AddScoped<ICompanyService, CompanyService>();
        service.AddScoped<IDepartmentService, DepartmentService>();
        service.AddScoped<IUserService, UserService>();

        //TODO: Is it good idea?!
        service.AddHttpContextAccessor();

        service.AddGrpc(options => {
            options.ResponseCompressionLevel = CompressionLevel.Optimal;
            options.ResponseCompressionAlgorithm = "gzip";
            options.MaxSendMessageSize = 1024 * 1024 * 1024; // 1 GB
            options.MaxReceiveMessageSize = 1024 * 1024 * 1024; // 1 GB
        });

        //TODO: Get from appesettings
        service.AddSingleton<IGrpcClientService>(provider =>
            new GrpcClientService("https://localhost:5001"));
    }

    public static void MapGrpcServices(WebApplication webApplication) {
        webApplication.MapGrpcService<GrpcClientService>();
    }
}