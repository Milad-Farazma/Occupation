namespace LearningManagement.Occupation.Application.OccupationSeniorityLevels.Dtos.Get;

public record OccupationSeniorityLevelDto(
    Guid Id,
    string? Description,
    Guid SeniorityLevelId,
    Guid OccupationId,
    OccupationSeniorityLevelDto.OccupationResponse Occupation) {
    public record OccupationResponse(
        Guid Id,
        string? Title,
        long Code,
        string? Description,
        string? BriefActivities,
        string? BannerUrl,
        string? IntroductionVideoUrl,
        string? BriefPersonality,
        decimal? MinimumSalary,
        decimal? MaximumSalary,
        decimal? ModeSalary,
        Guid JobOutlookId,
        Guid JobClassificationId);
}