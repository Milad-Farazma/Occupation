namespace LearningManagement.Occupation.Application.JobOutLooks.Dtos.Create;

public record CreateJobOutLookResponse(
    Guid Id,
    string? Title,
    long Code,
    string? Description,
    string? Icon,
    string? IconTitle
);