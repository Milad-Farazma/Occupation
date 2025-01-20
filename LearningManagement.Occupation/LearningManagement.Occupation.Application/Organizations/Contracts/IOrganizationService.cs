using LearningManagement.Occupation.Application.Organizations.Dto;

namespace LearningManagement.Occupation.Application.Organizations.Contracts;

public interface IOrganizationService {
    Task<OrganizationDto> CreateAsync(CreateOrganizationRequest request, CancellationToken cancellationToken = default);
    Task<OrganizationDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<IEnumerable<OrganizationDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(long id, UpdateOrganizationRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}