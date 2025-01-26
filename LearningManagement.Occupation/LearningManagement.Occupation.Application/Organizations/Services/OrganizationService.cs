using LearningManagement.Occupation.Application.Organizations.Contracts;
using LearningManagement.Occupation.Application.Organizations.Dto;
using LearningManagement.Occupation.Application.Organizations.Dto.Create;
using LearningManagement.Occupation.Application.Organizations.Dto.Get;
using LearningManagement.Occupation.Application.Organizations.Dto.Update;
using LearningManagement.Occupation.Domain.Organizations.Models;

namespace LearningManagement.Occupation.Application.Organizations.Services;

public class OrganizationService(IOrganizationRepository repo, IUserService userService) : IOrganizationService {
    public async Task<CreateOrganizationResponse> CreateAsync(CreateOrganizationRequest request, CancellationToken cancellationToken = default) {
        var organization = request.Adapt<Organization>();
        repo.Add(organization);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return organization.Adapt<CreateOrganizationResponse>();
    }

    public async Task<PaginatedResult<OrganizationDto>> GetAllAsync(PaginationRequest request,
        OrganizationSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<OrganizationDto>>();

    public async Task<OrganizationDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var organization = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken: cancellationToken);
        if (organization is null) throw new NotFoundException(new NotFoundError(id, nameof(Organization)));
        return organization.Adapt<OrganizationDto>();
    }

    public async Task UpdateAsync(long id, UpdateOrganizationRequest request, CancellationToken cancellationToken = default) {
        var organization = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (organization is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Organization)));

        request.Adapt(organization);
        repo.Update(organization);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var organization = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (organization is null) throw new NotFoundException(new NotFoundError(id, nameof(organization)));

        organization.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}