namespace LearningManagement.Occupation.Application.JobClassifications.Dtos.Create;

public record CreateJobClassificationResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description
);