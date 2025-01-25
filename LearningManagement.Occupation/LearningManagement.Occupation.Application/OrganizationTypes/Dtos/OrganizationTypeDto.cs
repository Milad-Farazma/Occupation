using LearningManagement.Occupation.Application.Organizations.Dto;

namespace LearningManagement.Occupation.Application.OrganizationTypes.Dtos;

public record OrganizationTypeDto(
    long Id,
    string Title,
    long Code,
    string Description,
    IEnumerable<OrganizationDto> Organizations
);