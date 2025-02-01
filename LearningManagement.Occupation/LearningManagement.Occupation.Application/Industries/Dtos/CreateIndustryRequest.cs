namespace LearningManagement.Occupation.Application.Industries.Dtos;

public record CreateIndustryRequest(
    string? Title,
    long Code,
    string? Description
);