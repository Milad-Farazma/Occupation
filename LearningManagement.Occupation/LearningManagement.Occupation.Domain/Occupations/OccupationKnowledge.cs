using LearningManagement.Occupation.Domain.Knowledges;

namespace LearningManagement.Occupation.Domain.Occupations;

public class OccupationKnowledge {
    public Guid OccupationId { get; set; }
    public Occupation Occupation { get; set; } = default!;
    
    public Guid KnowledgeId { get; set; }
    public Knowledge Knowledge { get; set; } = default!;
}