using LearningManagement.Occupation.Domain.EducationFieldSpecializations;

namespace LearningManagement.Occupation.Domain.EducationFields;

public class EducationField : ApprovableEntity {
    public string? Title { get; set; }

    public long Code { get; set; }

    public string? Description { get; set; }
    
    public ICollection<EducationFieldSpecialization> EducationFieldSpecializations { get; set; } = default!;
}