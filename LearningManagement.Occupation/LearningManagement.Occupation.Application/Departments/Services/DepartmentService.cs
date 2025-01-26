using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Dtos;
using LearningManagement.Occupation.Domain.Departments;

namespace LearningManagement.Occupation.Application.Departments.Services;

public class DepartmentService(IDepartmentRepository repo, IUserService userService) : IDepartmentService {
    public async Task<CreateDepartmentResponse> CreateAsync(CreateDepartmentRequest request, CancellationToken cancellationToken = default) {
        var department = request.Adapt<Department>();
        repo.Add(department);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return department.Adapt<CreateDepartmentResponse>();
    }

    public async Task<PaginatedResult<DepartmentDto>> GetAllAsync(PaginationRequest request,
        DepartmentSearchRequest? searchRequest, bool loadRelations,
        CancellationToken cancellationToken = default) => (await repo.GetAllAsync(false, request, searchRequest, loadRelations, cancellationToken))
        .Adapt<PaginatedResult<DepartmentDto>>();

    public async Task<DepartmentDto> GetByIdAsync(long id, bool loadRelations, CancellationToken cancellationToken = default) {
        var department = await repo.GetByIdAsync(id, true, loadRelations, cancellationToken);
        if (department is null) throw new NotFoundException(new NotFoundError(id, nameof(Department)));
        return department.Adapt<DepartmentDto>();
    }

    public async Task UpdateAsync(long id, UpdateDepartmentRequest request, CancellationToken cancellationToken = default) {
        var department = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (department is null)
            throw new NotFoundException(new NotFoundError(id, nameof(Department)));

        request.Adapt(department);
        repo.Update(department);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var department = await repo.GetByIdAsync(id, false, false, cancellationToken: cancellationToken);
        if (department is null) throw new NotFoundException(new NotFoundError(id, nameof(Department)));

        department.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}