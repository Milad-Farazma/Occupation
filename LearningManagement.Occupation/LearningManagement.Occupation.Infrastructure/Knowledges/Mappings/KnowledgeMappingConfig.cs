using LearningManagement.Occupation.Application.Knowledges.Dtos.Get;
using LearningManagement.Occupation.Domain.Knowledges;

namespace LearningManagement.Occupation.Infrastructure.Knowledges.Mappings;

public class KnowledgeMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<Knowledge, KnowledgeDto>.NewConfig()
            .Map(dest => dest.KnowledgeType, src => src.KnowledgeType);
    }
}