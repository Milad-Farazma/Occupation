using LearningManagement.Occupation.Application.JobPositions.Dtos;
using LearningManagement.Occupation.Application.JobPositions.Dtos.Get;
using LearningManagement.Occupation.Domain.JobPositions;

namespace LearningManagement.Occupation.Infrastructure.JobPositions.Mappings;

public class JobPositionMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<JobPosition, JobPositionDto>.NewConfig()
            .Map(dest => dest.Occupation, src => src.Occupation);
    }
}