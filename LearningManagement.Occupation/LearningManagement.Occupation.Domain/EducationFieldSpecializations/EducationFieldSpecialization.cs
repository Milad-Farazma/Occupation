using LearningManagement.Occupation.Domain.EducationFields;

namespace LearningManagement.Occupation.Domain.EducationFieldSpecializations;

public class EducationFieldSpecialization : ApprovableEntity {
    public string? Title { get; set; }
    
    public long Code { get; set; }

    public string? Description { get; set; }

    public long EducationFieldId { get; set; }

    public EducationField EducationField { get; set; } = default!;
}