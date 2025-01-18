using Grpc.Net.Client;
using MyApp.Grpc;

namespace LearningManagement.Occupation.Application.SampleGrpc;

public class GrpcClientService : IGrpcClientService {
    private readonly GrpcChannel _channel;
    private readonly MyService.MyServiceClient _client;

    public GrpcClientService(string grpcServerAddress) {
        _channel = GrpcChannel.ForAddress(grpcServerAddress);
        _client = new MyService.MyServiceClient(_channel);
    }

    public async Task<GetDataResponse> GetDataAsync(string id) {
        var request = new GetDataRequest { Id = id };
        return await _client.GetDataAsync(request);
    }

    public void Dispose() {
        _channel.Dispose();
    }
}