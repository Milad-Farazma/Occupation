using LearningManagement.Occupation.Application.OrganizationTypes.Contracts;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Create;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Get;
using LearningManagement.Occupation.Application.OrganizationTypes.Dtos.Update;
using LearningManagement.Occupation.Domain.OrganizationTypes;

namespace LearningManagement.Occupation.Application.OrganizationTypes.Services;

public class OrganizationTypeService(IOrganizationTypeRepository repo, IUserService userService) : IOrganizationTypeService {
    public async Task<CreateOrganizationTypeResponse> CreateAsync(CreateOrganizationTypeRequest request,
        CancellationToken cancellationToken = default) {
        var organizationType = request.Adapt<OrganizationType>();
        repo.Add(organizationType);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return organizationType.Adapt<CreateOrganizationTypeResponse>();
    }

    public async Task<PaginatedResult<OrganizationTypeDto>> GetAllAsync(PaginationRequest request,
        OrganizationTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<OrganizationTypeDto>>();

    public async Task<OrganizationTypeDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var organizationType = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken: cancellationToken);
        if (organizationType is null) throw new NotFoundException(new NotFoundError(id, nameof(OrganizationType)));
        return organizationType.Adapt<OrganizationTypeDto>();
    }

    public async Task UpdateAsync(long id, UpdateOrganizationTypeRequest request, CancellationToken cancellationToken = default) {
        var organizationType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (organizationType is null)
            throw new NotFoundException(new NotFoundError(id, nameof(OrganizationType)));

        request.Adapt(organizationType);
        repo.Update(organizationType);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var organizationType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (organizationType is null) throw new NotFoundException(new NotFoundError(id, nameof(OrganizationType)));

        organizationType.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}