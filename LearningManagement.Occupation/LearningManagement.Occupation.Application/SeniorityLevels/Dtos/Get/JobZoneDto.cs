namespace LearningManagement.Occupation.Application.SeniorityLevels.Dtos.Get;

public record SeniorityLevelDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    SeniorityLevelDto.OccupationSeniorityLevelResponse OccupationSeniorityLevel) {
    public record OccupationSeniorityLevelResponse(string? Description);
}