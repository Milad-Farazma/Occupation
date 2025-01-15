using Grpc.Core;
using LearningManagement.Occupation.Application;
using MyApp.Grpc;

namespace LearningManagement.Occupation.WebAPI.GrpcServices;

public class MyGrpcService(IMyUseCase useCase) : MyService.MyServiceBase {
    public override async Task<GetItemResponse> GetItem(GetItemRequest request, ServerCallContext context) {
        var result = await useCase.GetItemAsync(request.Id);

        return new GetItemResponse {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description
        };
    }
}