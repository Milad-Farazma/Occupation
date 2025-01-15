using Grpc.Core;
using LMS.Aquamation.Application;
using YourApp.Grpc;

namespace LMS.Aquamation.WebAPI;

public class YourGrpcService(IYourUseCase useCase) : YourService.YourServiceBase {
    public override async Task<GetItemResponse> GetItem(GetItemRequest request, ServerCallContext context) {
        var result = await useCase.GetItemAsync(request.Id);

        return new GetItemResponse {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description
        };
    }
}