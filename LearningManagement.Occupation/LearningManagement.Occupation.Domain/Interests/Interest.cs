using LearningManagement.Occupation.Domain.InterestTypes;

namespace LearningManagement.Occupation.Domain.Interests;

public class Interest : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }


    public long InterestTypeId { get; set; }
    public InterestType InterestType { get; set; } = default!;
}