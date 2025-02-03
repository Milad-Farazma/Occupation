namespace LearningManagement.Occupation.Application.JobOutLooks.Dtos;

public record UpdateJobOutLookRequest(
    string? Title,
    long Code,
    string? Description,
    string? Icon,
    string? IconTitle
);