namespace LearningManagement.Occupation.Application.Industries.Dtos;

public record CreateIndustryResponse(
    long Id,
    string? Title,
    long Code,
    string? Description
);