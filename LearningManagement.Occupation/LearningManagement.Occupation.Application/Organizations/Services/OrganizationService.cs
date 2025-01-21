using Framework.Data.SoftDelete;
using Framework.Exceptions;
using Framework.Pagination;
using Framework.Services.User;
using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.Organizations.Dto;
using LearningManagement.Occupation.Domain.Organizations.Models;
using Mapster;

namespace LearningManagement.Occupation.Application.Organizations.Services;

public class OrganizationService(IOrganizationRepository repo, IUserService userService) : IOrganizationService {
    public async Task<OrganizationDto> CreateAsync(CreateOrganizationRequest request, CancellationToken cancellationToken = default) {
        var organization = request.Adapt<Organization>();
        repo.Add(organization);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return organization.Adapt<OrganizationDto>();
    }

    public async Task<OrganizationDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default) {
        var organization = await repo.GetByIdAsync(id, asNoTracking: true, cancellationToken: cancellationToken);
        return organization?.Adapt<OrganizationDto>();
    }

    public async Task<PaginatedResult<OrganizationDto>> GetAllAsync(PaginationRequest request, CancellationToken cancellationToken = default) {
        var pagination = await repo.GetAllWithRelationsAsync(true, request, cancellationToken: cancellationToken);
        var result = pagination.Adapt<PaginatedResult<OrganizationDto>>();
        return result;
    }

    public async Task UpdateAsync(long id, UpdateOrganizationRequest request, CancellationToken cancellationToken = default) {
        var organization = await repo.GetByIdAsync(id, false, cancellationToken: cancellationToken);
        if (organization is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Organization)));

        request.Adapt(organization);
        repo.Update(organization);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var organization = await repo.GetByIdAsync(id, false, cancellationToken: cancellationToken);
        if (organization is null) throw new NotFoundException(new NotFoundError(id, nameof(organization)));

        organization.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}