using LearningManagement.Occupation.Application.JobOutLooks.Dtos.Get;
using LearningManagement.Occupation.Domain.JobOutLooks;

namespace LearningManagement.Occupation.Infrastructure.JobOutLooks.Mappings;

public class JobOutLookMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<JobOutLook, JobOutLookDto>.NewConfig()
            .Map(dest => dest.Occupations, src => src.Occupations);
    }
}