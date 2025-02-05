namespace LearningManagement.Occupation.Application.Aliases.Dtos.Create;

public record CreateAliasRequest(
    Guid OccupationId,
    string AlternativeTitle
);