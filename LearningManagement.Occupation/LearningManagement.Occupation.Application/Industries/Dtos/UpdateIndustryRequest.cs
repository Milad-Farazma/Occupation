namespace LearningManagement.Occupation.Application.Industries.Dtos;

public record UpdateIndustryRequest(
    string? Title,
    long Code,
    string? Description
);