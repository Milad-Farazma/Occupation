namespace LearningManagement.Occupation.Application.JobPositions.Dtos;

public record UpdateJobPositionRequest(
    Guid? ParentId,
    string? Title,
    ushort Capacity,
    Guid OrganizationId,
    Guid OccupationId
);