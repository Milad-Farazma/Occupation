using LearningManagement.Occupation.Application.InterestTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.InterestTypes;

namespace LearningManagement.Occupation.Infrastructure.InterestTypes.Mappings;

public class InterestTypeMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<InterestType, InterestTypeDto>.NewConfig()
            .Map(dest => dest.Interests, src => src.Interests);
    }
}