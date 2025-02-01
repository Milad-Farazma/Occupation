using LearningManagement.Occupation.Application.Interests.Dtos.Get;
using LearningManagement.Occupation.Domain.Interests;

namespace LearningManagement.Occupation.Infrastructure.Interests.Mappings;

public class InterestMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<Interest, InterestDto>.NewConfig()
            .Map(dest => dest.InterestType, src => src.InterestType);
    }
}