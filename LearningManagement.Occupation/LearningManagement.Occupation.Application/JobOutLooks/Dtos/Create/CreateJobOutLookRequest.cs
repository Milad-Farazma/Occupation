namespace LearningManagement.Occupation.Application.JobOutLooks.Dtos.Create;

public record CreateJobOutLookRequest(
    string? Title,
    long Code,
    string? Description,
    string? Icon,
    string? IconTitle
);