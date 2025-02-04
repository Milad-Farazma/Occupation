namespace LearningManagement.Occupation.Application.JobPositions.Dtos.Create;

public record CreateJobPositionResponse(
    long Id,
    Guid? ParentId,
    string? Title,
    ushort Capacity,
    Guid OrganizationId,
    Guid OccupationId
);