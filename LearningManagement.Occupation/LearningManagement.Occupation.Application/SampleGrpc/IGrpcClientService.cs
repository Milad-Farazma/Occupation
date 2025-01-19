namespace LearningManagement.Occupation.Application.SampleGrpc;

public interface IGrpcClientService : IDisposable {
    Task<GetDataResponse> GetDataAsync(string id);
}