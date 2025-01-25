namespace LearningManagement.Occupation.Application.EducationFields.Dtos;

public record EducationFieldDto(
    long Id,
    string Title,
    long Code,
    string Description,
    IEnumerable<EducationFieldDto.EducationFieldSpecializationsResponse> EducationFieldSpecializations) {
    public record EducationFieldSpecializationsResponse(string Title, long Code, string Description);
}