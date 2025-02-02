using LearningManagement.Occupation.Application.DepartmentTypes.Contracts;
using LearningManagement.Occupation.Application.DepartmentTypes.Dtos;
using LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Create;
using LearningManagement.Occupation.Application.DepartmentTypes.Dtos.Get;
using LearningManagement.Occupation.Domain.DepartmentTypes;

namespace LearningManagement.Occupation.Application.DepartmentTypes.Services;

public class DepartmentTypeService(IDepartmentTypeRepository repo, IUserService userService) : IDepartmentTypeService {
    public async Task<CreateDepartmentTypeResponse> CreateAsync(CreateDepartmentTypeRequest request, CancellationToken cancellationToken = default) {
        var departmentType = request.Adapt<DepartmentType>();
        repo.Add(departmentType);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return departmentType.Adapt<CreateDepartmentTypeResponse>();
    }

    public async Task<PaginatedResult<DepartmentTypeDto>> GetAllAsync(PaginationRequest request,
        DepartmentTypeSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<DepartmentTypeDto>>();

    public async Task<DepartmentTypeDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var departmentType = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (departmentType is null) throw new NotFoundException(new NotFoundError(id, nameof(DepartmentType)));
        return departmentType.Adapt<DepartmentTypeDto>();
    }

    public async Task UpdateAsync(long id, UpdateDepartmentTypeRequest request, CancellationToken cancellationToken = default) {
        var departmentType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (departmentType is null)
            throw new NotFoundException(new NotFoundError(id, nameof(DepartmentType)));

        request.Adapt(departmentType);
        repo.Update(departmentType);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var departmentType = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (departmentType is null) throw new NotFoundException(new NotFoundError(id, nameof(DepartmentType)));

        departmentType.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}