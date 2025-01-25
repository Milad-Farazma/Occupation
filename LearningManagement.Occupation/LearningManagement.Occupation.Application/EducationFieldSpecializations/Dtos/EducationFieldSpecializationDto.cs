namespace LearningManagement.Occupation.Application.EducationFieldSpecializations.Dtos;

public record EducationFieldSpecializationDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    EducationFieldSpecializationDto.EducationFieldResponse EducationField) {
    public record EducationFieldResponse(string? Title, long Code, string? Description);
}