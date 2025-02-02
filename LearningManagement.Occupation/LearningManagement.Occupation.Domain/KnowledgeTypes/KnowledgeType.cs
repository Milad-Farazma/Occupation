using LearningManagement.Occupation.Domain.Knowledges;

namespace LearningManagement.Occupation.Domain.KnowledgeTypes;

public class KnowledgeType : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }

    public ICollection<Knowledge> Knowledges { get; set; } = default!;
}