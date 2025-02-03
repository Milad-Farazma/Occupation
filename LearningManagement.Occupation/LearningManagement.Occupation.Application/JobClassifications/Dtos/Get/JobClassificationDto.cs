namespace LearningManagement.Occupation.Application.JobClassifications.Dtos.Get;

public record JobClassificationDto(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    IEnumerable<JobClassificationDto.OccupationResponse> Occupations) {
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