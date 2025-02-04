namespace LearningManagement.Occupation.Application.JobPositions.Dtos.Get;

public record JobPositionDto(
    Guid Id,
    Guid? ParentId,
    string? Title,
    ushort Capacity,
    Guid OrganizationId,
    Guid OccupationId,
    JobPositionDto.OccupationResponse Occupation) {
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
        decimal? ModeSalary);
}