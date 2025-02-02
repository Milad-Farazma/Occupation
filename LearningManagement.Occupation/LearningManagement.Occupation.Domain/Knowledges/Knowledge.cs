using LearningManagement.Occupation.Domain.KnowledgeTypes;

namespace LearningManagement.Occupation.Domain.Knowledges;

public class Knowledge : ApprovableEntity {
    public string? Title { get; set; }

    public int KnowledgeTypeId { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }

    public KnowledgeType KnowledgeType { get; set; } = default!;
}