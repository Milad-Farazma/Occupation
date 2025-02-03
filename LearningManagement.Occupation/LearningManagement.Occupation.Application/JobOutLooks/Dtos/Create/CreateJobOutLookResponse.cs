namespace LearningManagement.Occupation.Application.JobOutLooks.Dtos.Create;

public record CreateJobOutLookResponse(
    long Id,
    string? Title,
    long Code,
    string? Description,
    string? Icon,
    string? IconTitle
);