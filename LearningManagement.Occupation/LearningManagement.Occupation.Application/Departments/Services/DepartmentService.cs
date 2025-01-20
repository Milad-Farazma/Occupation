using Framework.Data.SoftDelete;
using Framework.Services.User;
using LearningManagement.Occupation.Application.Departments.Contracts;
using LearningManagement.Occupation.Application.Departments.Dto;
using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.Domain.Departments.Models;
using Mapster;

namespace LearningManagement.Occupation.Application.Departments.Services;

public class DepartmentService(IGenericRepository<Department> repo, IUserService userService) : IDepartmentService {
    public async Task<DepartmentDto> CreateAsync(CreateDepartmentRequest request, CancellationToken cancellationToken = default) {
        var department = request.Adapt<Department>();
        repo.Add(department);
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return department.Adapt<DepartmentDto>();
    }

    public async Task<DepartmentDto?> GetByIdAsync(long id, CancellationToken cancellationToken = default) {
        var department = await repo.GetByIdAsync(id, asNoTracking: true, cancellationToken: cancellationToken);
        return department?.Adapt<DepartmentDto>();
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync(CancellationToken cancellationToken = default) =>
        (await repo.GetAllAsync(asNoTracking: true, cancellationToken: cancellationToken))
        .Select(c => c.Adapt<DepartmentDto>());

    public async Task<ErrorOr<Success>> UpdateAsync(long id, UpdateDepartmentRequest request, CancellationToken cancellationToken = default) {
        var department = await repo.GetByIdAsync(id, cancellationToken: cancellationToken, asNoTracking: false);
        if (department is null)
            return Error.NotFound("Department.NotFound", "The Department with the specified ID was not found.");

        request.Adapt(department);
        repo.Update(department);

        await repo.SaveChangesAsync(cancellationToken: cancellationToken);

        return Result.Success;
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default) {
        var department = await repo.GetByIdAsync(id, cancellationToken: cancellationToken, asNoTracking: false);
        if (department is null) return;

        department.SoftDeleteInfo.SetDeleteObject(userService.GetCurrentUserId());
        await repo.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}