namespace LearningManagement.Occupation.Application.Industries.Dtos;

public sealed record IndustrySearchRequest(
    string? Title = null,
    long? Code = null,
    string? Description = null
);