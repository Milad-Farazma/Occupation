namespace LearningManagement.Occupation.Application.Interests.Dtos;

public record UpdateInterestRequest(
    string? Title,
    long Code,
    string? Description
);