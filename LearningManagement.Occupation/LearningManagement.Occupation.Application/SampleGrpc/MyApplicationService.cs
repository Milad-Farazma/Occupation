namespace LearningManagement.Occupation.Application.SampleGrpc;

public class MyApplicationService(IGrpcClientService grpcClientService) {
    public async Task<string> GetDataAsync(string id) {
        var response = await grpcClientService.GetDataAsync(id);
        return response.Data;
    }
}