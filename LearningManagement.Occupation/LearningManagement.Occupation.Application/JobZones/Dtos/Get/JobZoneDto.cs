namespace LearningManagement.Occupation.Application.JobZones.Dtos.Get;

public record JobZoneDto(
    long Id,
    string? Title,
    long Code,
    string? Description,
    JobZoneDto.OccupationJobZoneResponse OccupationJobZone) {
    public record OccupationJobZoneResponse(string? Description);
}