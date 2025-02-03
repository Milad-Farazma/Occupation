namespace LearningManagement.Occupation.Application.JobOutLooks.Dtos.Get;

public record JobOutLookDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    string? Icon,
    string? IconTitle,
    IEnumerable<JobOutLookDto.OccupationResponse> Occupations) {
    public record OccupationResponse(
        long Id,
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
        int JobOutlookId,
        int JobClassificationId);
}