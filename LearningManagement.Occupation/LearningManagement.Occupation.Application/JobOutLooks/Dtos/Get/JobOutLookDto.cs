namespace LearningManagement.Occupation.Application.JobOutLooks.Dtos.Get;

public record JobOutLookDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    string? Icon,
    string? IconTitle,
    IEnumerable<JobOutLookDto.OccupationResponse> Occupations) {
    public record OccupationResponse(
        Guid Id,
        string? Title,
        long Code,
        string? Description,
        string? BriefActivities,
        string? BannerImage,
        string? VideoDescription,
        string? BriefPersonality,
        decimal? MinimumSalary,
        decimal? MaximumSalary,
        decimal? ModeSalary,
        Guid JobOutlookId,
        Guid JobClassificationId);
}