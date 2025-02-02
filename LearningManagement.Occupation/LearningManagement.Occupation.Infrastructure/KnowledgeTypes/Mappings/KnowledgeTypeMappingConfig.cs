using LearningManagement.Occupation.Application.KnowledgeTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.KnowledgeTypes;

namespace LearningManagement.Occupation.Infrastructure.KnowledgeTypes.Mappings;

public class KnowledgeTypeMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        TypeAdapterConfig<KnowledgeType, KnowledgeTypeDto>.NewConfig()
            .Map(dest => dest.Knowledges, src => src.Knowledges);
    }
}