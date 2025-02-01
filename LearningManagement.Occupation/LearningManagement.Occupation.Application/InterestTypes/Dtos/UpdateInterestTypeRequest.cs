namespace LearningManagement.Occupation.Application.InterestTypes.Dtos;

public record UpdateInterestTypeRequest(
    string Title,
    string? Description
);