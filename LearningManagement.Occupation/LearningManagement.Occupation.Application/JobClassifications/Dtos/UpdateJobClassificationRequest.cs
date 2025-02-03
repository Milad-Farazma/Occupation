namespace LearningManagement.Occupation.Application.JobClassifications.Dtos;

public record UpdateJobClassificationRequest(
    string? Title,
    long Code,
    string? Description
);