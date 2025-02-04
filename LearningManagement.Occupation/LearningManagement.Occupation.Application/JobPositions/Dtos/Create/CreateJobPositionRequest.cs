namespace LearningManagement.Occupation.Application.JobPositions.Dtos.Create;

public record CreateJobPositionRequest(
    Guid? ParentId,
    string? Title,
    ushort Capacity,
    Guid OrganizationId,
    Guid OccupationId
);