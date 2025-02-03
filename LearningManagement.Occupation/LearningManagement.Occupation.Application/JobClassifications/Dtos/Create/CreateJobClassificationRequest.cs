namespace LearningManagement.Occupation.Application.JobClassifications.Dtos.Create;

public record CreateJobClassificationRequest(
    string? Title,
    long Code,
    string? Description
);