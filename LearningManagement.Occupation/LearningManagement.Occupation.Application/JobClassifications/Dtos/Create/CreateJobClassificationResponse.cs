namespace LearningManagement.Occupation.Application.JobClassifications.Dtos.Create;

public record CreateJobClassificationResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);