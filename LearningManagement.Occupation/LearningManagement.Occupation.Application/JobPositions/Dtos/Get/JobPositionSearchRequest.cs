namespace LearningManagement.Occupation.Application.JobPositions.Dtos.Get;

public sealed record JobPositionSearchRequest(
    Guid? ParentId = null,
    string? Title = null,
    ushort? Capacity = null
);